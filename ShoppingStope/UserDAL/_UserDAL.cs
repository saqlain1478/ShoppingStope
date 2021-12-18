using ShoppingStope.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace ShoppingStope.UserDAL
{
    public class _UserDAL
    {
        public static string constr = ConfigurationManager.ConnectionStrings["shp"].ConnectionString;
       static SqlConnection conobj = new SqlConnection(constr);
        public static Users Signup(Users obje)
        {
            
            var uusr = new Users();
            if (!string.IsNullOrEmpty(obje.Email)&& !string.IsNullOrEmpty(obje.Password))
            {
                try
                {
                    conobj.Open();
                    SqlCommand cmd = new SqlCommand("userpanel", conobj);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "userpanel"; // store procediure name
                    cmd.Parameters.AddWithValue("@email", obje.Email);
                    cmd.Parameters.AddWithValue("@password", obje.Password);
                    cmd.Parameters.AddWithValue("@callfrom", "lgn");
                    var result = cmd.ExecuteReader();
                   
                    var name = string.Empty;
                    var email = string.Empty;
                    var pas = string.Empty;
                    var id = string.Empty;
                   
                    
                    while (result.Read())
                    {
                        name = result["name"].ToString();
                        email = result["email"].ToString();
                        pas = result["password"].ToString();
                        id= result["Guid"].ToString();
                        SessionHelper._UserID = Convert.ToInt32(result["id"].ToString());
                    }
                    conobj.Close();
                    if (obje.Email == email && obje.Password == pas)
                    {
                        uusr.Firstname = name;
                        uusr.ID = id;
                        SessionHelper.Email = email;
                        uusr.isactive = true;
                        return uusr;
                    }
                    else
                    {
                        uusr.Firstname = string.Empty;
                        uusr.isactive = false;
                        return uusr;
                    }
                }
                catch (Exception ex)
                {
                    uusr.Firstname = string.Empty;
                    uusr.isactive = false;
                    return uusr;
                    
                }
            }
            else
            {
                try
                {
                    conobj.Open();
                    SqlCommand cmd = new SqlCommand("userpanel", conobj);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "userpanel"; // store procediure name
                    cmd.Parameters.AddWithValue("@name", obje.Firstname + " "+ obje.LastName);
                    cmd.Parameters.AddWithValue("@email", obje.Emaill);
                    cmd.Parameters.AddWithValue("@password", obje.Passwordd);
                    cmd.Parameters.AddWithValue("@phone", obje.phone);
                    cmd.Parameters.AddWithValue("@callfrom", "sgn");
                    var result = cmd.ExecuteNonQuery();
                    return uusr;
                }
                catch (Exception ex)
                {

                    uusr.Firstname = string.Empty;
                    uusr.isactive = false;
                    return uusr;
                }
            }

        }
        public static bool saveproductetials(products p)
        {

            try
            {
                conobj.Open();
                SqlCommand cmd = new SqlCommand("productssps", conobj);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "productssps"; // store procediure name
                cmd.Parameters.AddWithValue("@ItemNam", p.Name);
                cmd.Parameters.AddWithValue("@itemCategory", p.category);
                cmd.Parameters.AddWithValue("@itemsize", p.Size);
                cmd.Parameters.AddWithValue("@itemQty", p.Quantity);
                cmd.Parameters.AddWithValue("@itemFulldetials", p.itemDetails);
                cmd.Parameters.AddWithValue("@itemTags", p.group_tag);
                cmd.Parameters.AddWithValue("@ownerid",SessionHelper._UserID);
                cmd.Parameters.AddWithValue("@image", p.image1);
                cmd.Parameters.AddWithValue("@imagepath", p.imageUpload1);
                cmd.Parameters.AddWithValue("@image2", p.image2);
                cmd.Parameters.AddWithValue("@imag2", p.imageUpload2);
                cmd.Parameters.AddWithValue("@image3", p.image3);
                cmd.Parameters.AddWithValue("@imag3", p.imageUpload3);
                cmd.Parameters.AddWithValue("@image4", p.image4);
                cmd.Parameters.AddWithValue("@imag4", p.imageUpload4);
                cmd.Parameters.AddWithValue("@image5", p.image5);
                cmd.Parameters.AddWithValue("@imag5", p.imageUpload5);
                cmd.Parameters.AddWithValue("@image6", p.image6);
                cmd.Parameters.AddWithValue("@imag6", p.imageUpload6);
                cmd.Parameters.AddWithValue("@Callfrom", "AddPRd");
                cmd.ExecuteNonQuery();
                conobj.Close();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }

              
            
        }
            
    }
}