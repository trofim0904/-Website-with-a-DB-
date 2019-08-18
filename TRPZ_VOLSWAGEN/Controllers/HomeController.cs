using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TRPZ_VOLSWAGEN.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        //public string Index()
        //{
        //    string result = "Вы не авторизованы";
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        result = "Ваш логин: " + User.Identity.Name;
        //    }
        //    return result;
        //}



        public ActionResult more_information()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Picture()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        [Authorize]
        public ActionResult Shop()
        {
            return View();
        }

    }
}