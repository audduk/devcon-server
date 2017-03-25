using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebChecker.Models
{
    public class ServiceResponse
    {
        public bool LoginResult { get; set; }
    }

    public class User
    {
        public string Photo { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public Guid UserId { get; set; }
    }

}