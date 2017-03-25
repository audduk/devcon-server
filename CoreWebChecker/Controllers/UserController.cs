using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreWebChecker.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        //[HttpGet]
        //public IActionResult Index()
        //{
        //    return Content("Hello people");
        //}

        [HttpGet]
        [Route("Login")]
        public IActionResult Login(string login, string photo)
        {
            var user = new
            {
                LoginResult = false,
                Login = login,
                Phone = string.Empty
            };
            return Json(user);
        }

        [HttpGet]
        [Route("Register")]
        public IActionResult Register(string login= "", string userName= "", string photo= "")
        {
            var user = new
            {
                login = login,
                userName = userName,
                photo = photo
            };

            var result = new
            {
                LoginResult = false,
            };

            return Json(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Content("fdsfds");
        }
    }
}

