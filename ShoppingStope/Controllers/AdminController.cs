using ShoppingStope.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingStope.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
           return RedirectToAction("user");
        }
        [HttpGet]
        public ActionResult user()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult user(Users a)
        {
           var result = ShoppingStope.UserDAL._UserDAL.Signup(a);
            if(result.isactive==true && SessionHelper._UserID!=0)
            {
                result.Firstname = helper.Base64Encode(result.Firstname);
                result.ID = helper.Base64Encode(result.ID);
                string val =result.isactive.ToString();
                result.act = helper.Base64Encode(val);
                return RedirectToAction("Dashboard", result);
            }
            else
            {
                return RedirectToAction("user");
            }
            
        }
       
        [HttpGet]
        public ActionResult Dashboard(Users obj) {
           
            if(!string.IsNullOrEmpty(SessionHelper.Email) && SessionHelper._UserID!=0 && obj.isactive==true)
            {
                return View();
            }
            else
            {
                return RedirectToAction("user");
            }
         }




    }
}