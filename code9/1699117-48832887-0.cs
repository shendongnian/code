    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    
    namespace WebApplication12.Controllers
    {
        public class HomeController : Controller
        {
            [HttpPost]
            public ActionResult Login(LoginModel credential)
            {
                //code
                Response.Headers.Add("IndexHeader","IndexHeaderValue");
                return RedirectToAction("About");
            }
    
            public ActionResult About()
            {
                Response.Headers.Add("AboutHeader", "AboutHeaderValue");
                return View();
            }
        }
    
        public class LoginModel
        {
            public string username { get; set; }
            public string password { get; set; }
        }
    }
