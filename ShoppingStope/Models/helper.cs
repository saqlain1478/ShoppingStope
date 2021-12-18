using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;




namespace ShoppingStope.Models
{
    public class helper
    {
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
        public static string SaveimageinDirectrot(HttpPostedFileBase FIle)
        {
            var fileName = Path.GetFileName(FIle.FileName);
            var guid = Guid.NewGuid().ToString();
            string path = "~/Items/" + SessionHelper._UserID + "," + guid + "," + fileName;
            FIle.SaveAs(System.Web.Hosting.HostingEnvironment.MapPath(path));
            return path;
        }
        public static byte[] convertimagetobinary(HttpPostedFileBase postedFile)
        {

            byte[] bytes;
            BinaryReader br = new BinaryReader(postedFile.InputStream);

            bytes = br.ReadBytes(postedFile.ContentLength);
            return bytes;
        }

    }

}