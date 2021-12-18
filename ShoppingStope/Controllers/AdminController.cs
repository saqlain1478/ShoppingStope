using ShoppingStope.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
           
            if(!string.IsNullOrEmpty(callfom))
            {
                callfom = null;
                return View();
            }
            else
            {
                if (!string.IsNullOrEmpty(SessionHelper.Email) && SessionHelper._UserID != 0 && obj.isactive == true)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("user");
                }
            }
           
         }
        static string callfom ;
        public ActionResult Addproduct(products p, HttpPostedFileBase imageUpload1, HttpPostedFileBase imageUpload2, HttpPostedFileBase imageUpload3, HttpPostedFileBase imageUpload4,
            HttpPostedFileBase imageUpload5, HttpPostedFileBase imageUpload6)
        {

            
            try
            {

                if (imageUpload1 != null)
                {
                  p.imageUpload1= helper.SaveimageinDirectrot(imageUpload1);
                    p.image1 = helper.convertimagetobinary(imageUpload1);
                }
                if (imageUpload2 != null)
                {
                    p.imageUpload2 = helper.SaveimageinDirectrot(imageUpload2);
                    p.image2 = helper.convertimagetobinary(imageUpload2);
                }
                if (imageUpload3 != null)
                {
                    p.imageUpload3 = helper.SaveimageinDirectrot(imageUpload3);
                    p.image3 = helper.convertimagetobinary(imageUpload3);
                }
                if (imageUpload4 != null)
                {
                    p.imageUpload4 = helper.SaveimageinDirectrot(imageUpload4);
                    p.image4 = helper.convertimagetobinary(imageUpload4);
                }
                if (imageUpload5 != null)
                {
                    p.imageUpload5 = helper.SaveimageinDirectrot(imageUpload5);
                    p.image5 = helper.convertimagetobinary(imageUpload5);
                }
                if (imageUpload5 != null)
                {
                    p.imageUpload6 = helper.SaveimageinDirectrot(imageUpload6);
                    p.image6 = helper.convertimagetobinary(imageUpload6);
                }
                
                ShoppingStope.UserDAL._UserDAL.saveproductetials(p);
                return RedirectToAction("Dashboard", "Admin");//test only 

            }
            catch (Exception)
            {
                callfom = "Addprod";
                return RedirectToAction("Dashboard", "Admin");
            }
           
        }




    }
}