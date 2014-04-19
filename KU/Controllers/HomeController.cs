using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KU.Controllers;

namespace KU.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login","Account");
            string redirectString = UserRoleRedirect();
            int redirectStringLength = redirectString.Length;
            if (redirectString.Substring(0, redirectStringLength).Contains("Home"))
                return View();
            else
                return RedirectToAction("Index", redirectString);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        #region RedirectHelper
        public string UserRoleRedirect()
        {
            string redirectString = "Home";

            if (User.IsInRole("Kurier"))
                redirectString = "IK";
            if (User.IsInRole("Konsultant tel"))
                redirectString = "KonsOM";
            if (User.IsInRole("Admin"))
                redirectString = "Home";
                
            return redirectString;
        }
        #endregion
    }
}