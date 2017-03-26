using System;
using System.IO;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreWebChecker.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IFaceServiceClient faceServiceClient = new FaceServiceClient("ed266f177810476aa3ad9c4b7c588e48");
        //private readonly string imageFileName = "C:\\Users\\Pavel\\Pictures\\Фото\\IMG_2628_.JPG";
        //private readonly string imageFileName = "C:\\Users\\Pavel\\Pictures\\Фото\\IMG_2509_.JPG";
        private readonly string groupName = "aliance_bio_pgroup";

        //[HttpGet]
        //public IActionResult Index()
        //{
        //    return Content("Hello people");
        //}

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(string login, [FromBody] byte[] photo)
        {

            // TODO По логину получить данные из базы
            string Login = login;
            string UserName = "Иванов Иван Ивановаич";
            string Phone = "79001000000";
            // В том числе personId (пока что заглушка)
            Guid personId = Guid.Parse("d7a7411f-9a84-4547-8096-f61972a34baf");

            // Результат обработки
            bool LoginResult = false;

            try
            {
                using (Stream imageFileStream = new MemoryStream(photo))
                {
                    Face[] faces = await faceServiceClient.DetectAsync(imageFileStream);
                    if (faces.Length != 1)
                        throw new Exception("Ошибка идентификации. Несколько лиц!");
                    Face face = faces[0];
                    VerifyResult verifyResult = await faceServiceClient.VerifyAsync(face.FaceId, groupName, personId);

                    LoginResult = verifyResult.IsIdentical;
                }
            }
            catch (Exception ex)
            {
                var result = new
                {
                    LoginResult = false,
                    Message = "Ошибка при регистрации, возможно такой пользователь уже зарегистрирован",
                    ErrorMessage = ex.Data["ErrorMessage"],
                };
                return Json(result);
            }

            if (LoginResult)
                return Json(new
                {
                    LoginResult = LoginResult,
                    UserName = UserName,
                    Phone = Phone,
                    PersonId = personId,
                });
            else
                return Json(new
                {
                    LoginResult = LoginResult,
                });
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(string login, [FromBody] byte[] photo, string userName = "")
        {
            var user = new
            {
                login = login,
                userName = userName,
                photo = photo
            };

            // проверить по логину запись в базе данных
            // если такая запись есть, обломать
            // ...
            // ...
            // ...

            //если такой записи нет, регистрируем - получаем новый PersonnId
            try
            {
                using (Stream imageFileStream = new MemoryStream(photo))
                {
                    //await faceServiceClient.CreatePersonGroupAsync(groupName, groupName); // считаем, что у нас уже зарегистрироавна группа
                    CreatePersonResult person = await faceServiceClient.CreatePersonAsync(groupName, userName);
                    AddPersistedFaceResult faceResult = await faceServiceClient.AddPersonFaceAsync(groupName, person.PersonId, imageFileStream);

                    var result = new
                    {
                        RegisterResult = true,
                        PersonId = person.PersonId
                    };
                    return Json(result);
                }
            } catch (Exception ex)
            {
                var result = new
                {
                    RegisterResult = false,
                    Message = "Ошибка при регистрации, возможно такой пользователь уже зарегистрирован",
                    ErrorMessage = ex.Data["ErrorMessage"],
                };
                return Json(result);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Content("fdsfds");
        }
    }
}

