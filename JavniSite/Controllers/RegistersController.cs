using JavniSite.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace JavniSite.Controllers
{
    public class RegistersController : Controller
    {


        [HttpGet]
        public ActionResult InsertDetails()
        {

            return View();
        }
        [HttpGet]
        public ActionResult Index()
        {
            //return RedirectToAction("PopulateData", "Registers");
            return View();
        }
        //   Login l = new Login();
        [HttpPost]
        public ActionResult Index(Login login)
        {

            if (login.username == "admin" && login.password == "admin")
            {
                return Redirect("http://localhost:51027/PopisKorisnika.aspx");
            }

            //HttpCookie userCookie = new HttpCookie("user", login.Id.ToString());
            //userCookie.Expires.AddDays(10);
            //HttpContext.Response.SetCookie(userCookie);
            //HttpCookie newCookie = Request.Cookies["user"];
            //return newCookie.Value;

         
            if (ModelState.IsValid) // Check the model state for any validation errors
            {
                if (Request.Cookies["Kalorije"] == null)
                {
                    ViewBag.Message = "Cookie expired";
                    return View();
                }
                if (login.checkUser(login.username, login.password)) // Calls the Login class checkUser() for existence of the user in the database.
                {

                    Response.Cookies.Add(new HttpCookie("Username", login.username));
                    //Response.Cookies.Add(new HttpCookie("Sifra", obj.Password));
                    //Response.Cookies.Add(new HttpCookie("Kalorije", obj.CalorieIntake(intake).ToString()));
                    return RedirectToAction("PopulateData", login); // Return the "Show.cshtml" view if user is valid


                }
                else
                {
                    ViewBag.Message = "Invalid Username or Password";
                    return View(); //return the same view with message "Invalid Username or Password"
                }
            }
            else
            {
                return View(); // Return the same view with validation errors.
            }

            return View();

        }

        public ActionResult AfterLogin(int id)
        {
            User u = new User();// select your user's data using id and assign to a user object 
            return View(u); // and pass the user object to view
        }




        [HttpPost]
        public ActionResult InsertDetails(User obj)
        {
            //   User objreg = new User();
            //   string result = objreg.
            //   ViewData["result"] = result;
            //   ModelState.Clear();

            if (ModelState.IsValid)
            {
                if ((obj.checkUser(obj.UserName, obj.Email)) == false)
                {
                    int intake = 1;
                    obj.CalorieIntake(intake);
                    Response.Cookies.Add(new HttpCookie("Username", obj.UserName));
                    Response.Cookies.Add(new HttpCookie("Sifra", obj.Password));
                    // Response.Cookies.Add(new HttpCookie("Kalorije", obj.CalorieIntake(intake).ToString()));
                    HttpCookie cookie = new HttpCookie("Kalorije", obj.CalorieIntake(intake).ToString());
                    cookie.Expires = DateTime.Now.AddDays(2);
                    Response.Cookies.Add(cookie);
                    // Response.Cookies.Add(new HttpCookie("Fruit", questions.Fruit));
                    //RedirectToAction("MyAnswers");

                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
                    SqlCommand cmd = new SqlCommand();

                    //Creating function to insert details
                    cmd.CommandText = "Insert into [Registracija]  ([Ime] ,[Prezime],[DatumRodenja] ,[Visina],[Tezina],[Spol] ,[Tip],[Aktivost]" +
                            ",[Email],[Username],[Sifra],[Kalorije]) values('" + obj.Name + "','" + obj.Surname + "','" + (DateTime)obj.Dateofbirth + "','" + obj.Visina + "','" + obj.Tezina + "'" +
                            ",'" + obj.Gender + "','" + obj.Activity + "','" + obj.Diabetes + "','" + obj.Email + "','" + obj.UserName + "','" + obj.Password + "','" + (int)obj.CalorieIntake(intake) + "')";
                    cmd.Connection = con;

                    //   try
                    //   {

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    return RedirectToAction("Index", "Registers");

                }
            }
            return View(obj);


            ////   Reporting();


        }


        public ActionResult PopulateData(string a)
        {


            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            //SqlDataAdapter sqlCommand = new SqlDataAdapter("ViewAll", con);
            //sqlCommand.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dataTable = new DataTable();
            if (a == "action1")
            {
                try
                {
                    SqlDataAdapter sda = new SqlDataAdapter("jela", con);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.Fill(dataTable);
                }
                catch (Exception)
                {
                    throw;
                }// The first button was used to submit the form
                 // return View(dataTable);
            }
            if (a == "action2")
            {
                try
                {
                    User u = new User();
                    //  SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=pra;Integrated Security=True");
                    SqlCommand cmd = new SqlCommand();

                    //Creating function to insert details
                    cmd.CommandText = "Danas";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@datum", DateTime.Now);
                    //   try
                    //   {

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception)
                {
                    throw;
                }// The first button was used to submit the form
                 // return View(dataTable);
            }


            try
            {
                if (Request.Cookies["Kalorije"] != null)
                {

                    var cookie = Request.Cookies["Kalorije"].Value;
                    //if (HttpContext.Request.Cookies["Kalorije"] != null)
                    //{


                    //HttpCookie cookie = HttpContext.Request.Cookies.Get("Kalorije");

                    SqlCommand cmd = new SqlCommand("ViewJela", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //   cmd.Parameters.AddWithValue("@kcal", cookie);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dataTable);
                    //   HttpContext.Response.SetCookie(cookie);
                }
                else
                {
                    ViewBag.Message = "Cookie expired";
                    return View();
                }


            }
            catch (Exception)
            {
                throw;
            }

            return View(dataTable);    //return View(dataTable);


        }

        public ActionResult Jelovnik(Povist dr)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            string s1 = "select  Mealss, Namirnica,TipNamirnice,[Mjerna  jedinica]" +
                ",DatumJelovnika from Namirnicejoin TipNamirnice on Namirnice.TipNamirnice_ID = " +
                "TipNamirnice.ID_TipNamirnicejoin Meals on Namirnice.ObrokID = Meals.ID_Meals ";
            SqlCommand cmd = new SqlCommand(s1, con);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            List<Povist> p = new List<Povist>();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    var details = new Povist();
                    details.Meals = sdr["Meals"].ToString();
                    details.Namirnica = sdr["Namirnica"].ToString();
                    details.TipNamirnice = sdr["TipNamirnice"].ToString();
                    details.MjernaJedinica = sdr["MjernaJedinica"].ToString();
                    details.Datum = sdr["Datum"].ToString();

                }
                dr.userinfo = p;
                con.Close();
            }
            return View("Jelovnik", dr);
        }


        //public ActionResult PopulateDatas(string a)
        //{


        //    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=pra;Integrated Security=True");
        //    //SqlDataAdapter sqlCommand = new SqlDataAdapter("ViewAll", con);
        //    //sqlCommand.SelectCommand.CommandType = CommandType.StoredProcedure;
        //    DataTable dataTable = new DataTable();
        //    if (a == "action2")
        //    {
        //        try
        //        {
        //            SqlDataAdapter sda = new SqlDataAdapter("RandomNamirnice", con);
        //            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
        //            sda.Fill(dataTable);
        //        }
        //        catch (Exception)
        //        {
        //            throw;
        //        }// The first button was used to submit the form
        //         // return View(dataTable);
        //    }

        //    return View(dataTable);    //return View(dataTable);


        //}
        //public ActionResult Povijest(Povist p)
        //{
        //    //SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=pra;Integrated Security=True");
        //    //DataTable dataTable = new DataTable();
        //    //con.Open();
        //    ////  chkbox_selected += CheckBoxList1.Items[i].Value + ",";
        //    //SqlCommand sqlCommand = new SqlCommand("povijest", con);
        //    //sqlCommand.CommandType = CommandType.StoredProcedure;
        //    //sqlCommand.Parameters.AddWithValue("@datum",p.Dateofbirth);
        //    //SqlDataAdapter sda = new SqlDataAdapter(sqlCommand);
        //    //sda.Fill(dataTable);
        //    //sqlCommand.ExecuteNonQuery();

        //    //con.Close();


        //    if (p.checkUser(p.Dateofbirth)) // Calls the Login class checkUser() for existence of the user in the database.
        //    {


        //        return RedirectToAction("PopulateData", p); // Return the "Show.cshtml" view if user is valid


        //    }


        //    return View();
        //}



    }

}