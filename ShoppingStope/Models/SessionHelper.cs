using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingStope.Models
{
    public class SessionHelper
    {
        public static int _UserID
        {
            set
            {
                HttpContext.Current.Session["uid"] = value;
            }
            get
            {
                return int.Parse((HttpContext.Current != null && HttpContext.Current.Session != null && HttpContext.Current.Session["uid"] == null) ? "0" : HttpContext.Current.Session["uid"].ToString());
            }
        }
        public static String Email
        {
            set
            {
                HttpContext.Current.Session["Email"] = value;
            }
            get
            {
                return ((HttpContext.Current != null && HttpContext.Current.Session != null && HttpContext.Current.Session["Email"] == null) ? "0" : HttpContext.Current.Session["Email"].ToString());
            }
        }
    }
}