using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingStope.Models
{
    public class User
    {
        public string ID { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string imagepath { get; set; }
        public bool isactive { get; set; }




    }
}