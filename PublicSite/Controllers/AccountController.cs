using PublicSite.Models;
using PublicSite.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PublicSite.Controllers
{

    public class AccountController : Controller
    {
        // GET: /Account/SignUp
        public ActionResult SignUp()
        {
            return View("SignUp");
        }

        // POST: /Account/SignUp
        [HttpPost]
        public ActionResult SignUp(UserView user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserManager userManager = new UserManager();
                    if (!userManager.IsUserLoginIDExist(user.Email))
                    {
                        userManager.Add(user);
                        FormsAuthentication.SetAuthCookie(user.Name, false);
                        return RedirectToAction("Welcome", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "LogID already taken");
                    }
                }
            }
            catch
            {
                return View(user);
            }

            return View(user);
        }
    }
}
