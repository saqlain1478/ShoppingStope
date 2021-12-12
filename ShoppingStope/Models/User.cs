using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingStope.Models
{
    public class Users
    {
        public string ID { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string phone { get; set; }
        public string Email { get; set; }
        public string Emaill { get; set; }
        public string Password { get; set; }
        public string Passwordd { get; set; }

        public string Gender { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string imagepath { get; set; } = string.Empty;
        public bool isactive { get; set; }
        public string act { get; set; }




    }
}