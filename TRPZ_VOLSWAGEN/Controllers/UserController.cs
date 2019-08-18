using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TRPZ_VOLSWAGEN.Models.Data;
using TRPZ_VOLSWAGEN.Models.User;


namespace TRPZ_VOLSWAGEN.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                // поиск пользователя в бд
                UserDTO user = null;
                using (StoreDb db = new StoreDb())
                {
                    user = db.User.FirstOrDefault(u => u.Login == model.Name && u.Password == model.Password);

                }
                if (user != null)
                {
                    if (model.Name == "admin")
                        return RedirectToAction("Index", "Pages", new { area = "Admin", controller = "Pages" });
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }
            }

            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                UserDTO user = null;
                using (StoreDb db = new StoreDb())
                {
                    user = db.User.FirstOrDefault(u => u.Login == model.Name);
                }
                if (user == null)
                {
                    // создаем нового пользователя
                    using (StoreDb db = new StoreDb())
                    {
                        db.User.Add(new UserDTO { Login = model.Name, Password = model.Password });
                        db.SaveChanges();

                        user = db.User.Where(u => u.Login == model.Name && u.Password == model.Password).FirstOrDefault();
                    }
                    // если пользователь удачно добавлен в бд
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Name, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }
            }

            return View(model);
        }
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Exit()
        {
         
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        //[HttpGet]
        //public ActionResult Registration()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Registration(UserVM model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    using (StoreDb storeDb = new StoreDb())
        //    {


        //        UserDTO userDTO = new UserDTO();
        //        userDTO.Login = model.Login;



        //        if (storeDb.User.Any(x => x.Login == model.Login))
        //        {
        //            ModelState.AddModelError("", "This login already exist!!!");
        //            return View(model);
        //        }


        //        userDTO.Login = model.Login;
        //        userDTO.Password = model.Password;


        //        storeDb.User.Add(userDTO);
        //        storeDb.SaveChanges();
        //    }

        //    TempData["SM"] = "Account added";
        //    return RedirectToAction("Index");


        //}
    }
}