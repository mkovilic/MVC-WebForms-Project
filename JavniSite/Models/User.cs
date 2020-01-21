using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JavniSite.Models
{
    public class User
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Name e.g. Mate")]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Name e.g. Kovilic")]
        [StringLength(30, MinimumLength = 3)]
        public string Surname { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Dateofbirth { get; set; }
        //[Required(ErrorMessage = "Please Enter Name e.g. Mate")]
        //[StringLength(30, MinimumLength = 3)]
        //public string Dateofbirth { get; set; }

        [Range(120, 210)]
        public int Visina { get; set; }

        [Required]
        [Range(50, 300)]
        public int Tezina { get; set; }
        [Required]
        public string Gender { get; set; }

        [Required]
        public string Activity { get; set; }

        [Required]
        public string Diabetes { get; set; }


        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        private int f_spol = 0;
        private double f_aktivnost;
        private double f_tip_dijabetesa;


        public int CheckGender(int f_spol)
        {
            if (Gender == "M")
            {
                this.f_spol += 5;
            }
            else if (Gender == "Z")
            {
                this.f_spol -= 161;
            }
            return f_spol;

        }
        public double CheckActivity(double f_aktivnost)
        {
            if (Activity == "Niska")
            {
                this.f_aktivnost = 1.2;
            }
            else if (Activity == "Srednja")
            {
                this.f_aktivnost = 1.375;
            }
            else if (Activity == "Visoka")
            {
                this.f_aktivnost = 1.5;
            }
            return f_aktivnost;
        }
        public double CheckDiabetes(double f_tip_dijabetesa)
        {
            if (Diabetes == "1")
            {

                this.f_tip_dijabetesa = 0.99;
            }
            else if (Diabetes == "2")
            {
                this.f_tip_dijabetesa = 0.98;
            }
            return f_tip_dijabetesa;
        }

        private double tezina = 0;
        public double Weight(double tezina)
        {
            this.tezina += (Tezina * 6.25);
            return tezina;
        }
        private int visina = 0;
        public int Height(int visina)
        {
            this.visina += (Visina * 10);
            return visina;
        }

        int age = 0;
        public int Age(int age)
        {

            DateTime now = DateTime.Today;
            this.age = now.Year - this.Dateofbirth.Year;
            if (this.Dateofbirth > now.AddYears(-age)) age--;
            return age;
        }


        public int CalorieIntake(int intake)
        {
            intake = (int)((Weight(tezina) + Height(visina) - (5 * Age(age)) + CheckGender(f_spol)) * CheckActivity(f_aktivnost) * CheckDiabetes(f_tip_dijabetesa));
            return intake;
        }
        public double intake;
        public bool checkUser(string username, string email) //This method check the user existence
        {
            bool flag = false;
            //   string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString; // Read the connection string from the web.config file
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select count(*) from Registracija where Username='" + username + "' or Email='" + email + "'", con);
                //   SqlCommand cmd = new SqlCommand("Select count(*) from Registracija join Namirnice on Namirnice.username = Registracija.Username where  Namirnice.username='" + username + "'", con);

                flag = Convert.ToBoolean(cmd.ExecuteScalar());
                return flag;
            }

            //SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=pra;Integrated Security=True");
            //SqlCommand cmd = new SqlCommand();

            ////Creating function to insert details
            //public string InsertRegDetails(User obj)
            //{

            //    cmd.CommandText = "Insert into [Registracija]  ([Ime] ,[Prezime],[DatumRodenja] ,[Visina],[Tezina],[Spol] ,[Tip],[Aktivost],[Email],[Username],[Sifra]) values('" + obj.Name + "','" + obj.Surname + "','" + obj.Dateofbirth + "','" + obj.Visina + "','" + obj.Tezina + "'" +
            //            ",'" + obj.Gender + "','" + obj.Activity + "','" + obj.Diabetes + "','" + obj.Email + "','" + obj.UserName + "','" + obj.Password + "')";
            //    cmd.Connection = con;

            //    //   try
            //    //   {

            //    con.Open();
            //    cmd.ExecuteNonQuery();
            //    con.Close();
            //    return "Success";
            //    //  }
            //    //catch (Exception e)
            //    //{

            //    //    throw e;
            //    //}


            //}

        }
    }
}




