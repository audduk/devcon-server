using CheckLogin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CheckLogin.Controllers
{
    public class HomeController : Controller
    {
        public string Register(string login, string phone,byte[] photo)
        {
            string json = JsonConvert.SerializeObject(new
            {
                result = new Result()
                {
                    LoginResult = false
                }
            });

            return json;
        }

        public string Login(string login,byte[] photo)
        {
            string json = JsonConvert.SerializeObject(new
            {
                result = new Result()
                {
                    LoginResult = false, 
                    Login = login, 
                    Phone = string.Empty
                }
            });

            return json;
        }

        public string GetHelloWorld()
        {
            return "Hello world";
        }
    }
}