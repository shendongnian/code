    using FoodieWeb.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    namespace FoodieWeb.Controllers
    {
        public class UserLoginController : Controller
        {
            private UsersModelContext db = new UsersModelContext();
            // GET: UserLogin
            public ActionResult UserLogin()
            {
                return View();
            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult UserLogin(UsersModel usersModel)
            {
                string email = Request.Form["email"];
                string password = Request.Form["password"];
                UsersModel users = db.UsersModel.FirstOrDefault(x=>x.email==email);
                if (ModelState.IsValid&&users!=null)
                {
                    if ((email.Equals(users.email)) && (password.Equals(users.password)))
                    {
                        Session["Email"] = email;
                        Session["LoggedIn"] = "yes";
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return View("~/Views/UserLogin/UserLogin.cshtml");
                    }
                }
                return View(usersModel);
            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult UserLogOff()
            {
                //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                System.Web.HttpContext.Current.Session["LoggedIn"] = null;
                return RedirectToAction("Index", "Home");
            }
            public object[] UsersModelID { get; set; }
        }
    }
