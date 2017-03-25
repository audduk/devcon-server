using Newtonsoft.Json;
using System;
using System.Web.Http;
using WebChecker.Models;

namespace WebChecker.Controllers
{
    public class UserController : ApiController
    {

        public string GetUserGreeting()
        {
            return "Hello people";
        }

        public string GetUser(string login, string photo)
        {
            string json = JsonConvert.SerializeObject(new
            {
                ServiceResponse = new ServiceResponse()
                {
                    LoginResult = false,
                }
            });

            return json;
        }

        //[HttpPost]
        public string GetUserRegister(string login, string phone, string name, string photo)
        {
            
            string json = JsonConvert.SerializeObject(new
            {
                ServiceResponse = new ServiceResponse()
                {
                    LoginResult = false, 
                }
            });

            var newUser = new User()
            {
                Photo = photo,
                Login = login,
                Name = name,
                Phone = photo,
                UserId = Guid.NewGuid()
            };

            return json;
        }
    }
}
