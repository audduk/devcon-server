using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
                result = new Result()
                {
                    LoginResult = false,
                    Login = login,
                    Phone = string.Empty
                }
            });

            return json;
        }

        //[HttpPost]
        public string GetUserRegister(string login, string phone, string photo)
        {
            string json = JsonConvert.SerializeObject(new
            {
                result = new Result()
                {
                    LoginResult = false,
                    Login = login
                }
            });

            return json;
        }
    }
}
