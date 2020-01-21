using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Web;
using Xunit;

namespace JavniSite.Models
{
    public class Login
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Username is required")] // make the field required
        [Display(Name = "Username")]  // Set the display name of the field
        public string username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password")]
        public string password { get; set; }
        public bool checkUser(string username,string password) //This method check the user existence
        {
            bool flag = false;
            //   string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString; // Read the connection string from the web.config file
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select count(*) from Registracija where Username='" + username + "' and Sifra='" + password + "'", con);
             //   SqlCommand cmd = new SqlCommand("Select count(*) from Registracija join Namirnice on Namirnice.username = Registracija.Username where  Namirnice.username='" + username + "'", con);

                flag = Convert.ToBoolean(cmd.ExecuteScalar());
                return flag;
            }
        }
        public bool checks(int id)
        {
            bool flag = false;
            //   string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString; // Read the connection string from the web.config file
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
            {
                con.Open();
               // SqlCommand cmd = new SqlCommand("Select count(*) from Registracija where Username='" + username + "' and Sifra='" + password + "'", con);
                 SqlCommand cmd = new SqlCommand("Select count(*) from Registracija join Namirnice on Namirnice.reg_id = Registracija.Id_registracija where  Namirnice.reg_id='" + id + "'", con);

                flag = Convert.ToBoolean(cmd.ExecuteScalar());
                return flag;
            }

        }

        public void ss(string username)
        {
         //   this username;
            //   string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString; // Read the connection string from the web.config file
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
            {
                con.Open();
                // SqlCommand cmd = new SqlCommand("Select count(*) from Registracija where Username='" + username + "' and Sifra='" + password + "'", con);
                SqlCommand cmd = new SqlCommand("Select Kalorije from Registracija where Username='"+ username + "'", con);

             
            }

        }
        public void sss(string username)
        {
            //   this username;
            //   string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString; // Read the connection string from the web.config file
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
            {
                con.Open();
                // SqlCommand cmd = new SqlCommand("Select count(*) from Registracija where Username='" + username + "' and Sifra='" + password + "'", con);
                SqlCommand cmd = new SqlCommand("Select Kalorije from Registracija where Username='" + username + "'", con);


            }

        }
    }
}