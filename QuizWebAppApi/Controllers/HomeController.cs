using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizWebAppApi.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]//Don't ask them to log in/ you can see just see it.
        public ActionResult Index()
        {
            var clientId = ConfigurationManager.AppSettings["googleClientId"];
            var Secret= ConfigurationManager.AppSettings["googleSecret"];

            return View();
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
    }
}