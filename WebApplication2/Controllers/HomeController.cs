using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models.EntityManager;
using WebApplication2.Models.ViewModel;
using static WebApplication2.Models.EntityManager.UserManager;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Welcome (string a)
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
                    UserModel u = new UserModel();
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

        [Authorize]
        public ActionResult EditProfile()
        {
            string loginName = User.Identity.Name;
            UserManager UM = new UserManager();
            UserProfileView UPV = UM.GetUserProfile(UM.GetUserID(loginName));
            return View(UPV);
        }


        [HttpPost]
        [Authorize]
        public ActionResult EditProfile(UserProfileView profile)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();
                UM.UpdateUserAccount(profile);

                ViewBag.Status = "Update Sucessful!";
            }
            return View(profile);
        }

    }
}