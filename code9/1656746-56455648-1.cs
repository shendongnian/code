    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Data.Linq;
    using MvcApplication1.Models;
    
    namespace MvcApplication1.Controllers
    {
        public class HomeController : Controller
        {
           
            public ActionResult Index()
            {
              
                return View();
             
            }
            public ActionResult ShowData()
            {
                DataContext dc = new DataContext("connectionstring");
                 List<student> lst = dc.GetTable<student>().ToList();
                return Json(lst,JsonRequestBehavior.AllowGet);
            }
        }
    }
