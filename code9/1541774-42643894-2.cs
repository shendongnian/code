            //use this
            
            using System;
            using System.Collections.Generic;
            using System.Linq;
            using System.Web;
            using System.Web.Mvc;
            using System.Web.Routing;
            
            namespace nullReference_Exception.Models
            {
                public class CustomException : FilterAttribute, IExceptionFilter
                {
                    public void OnException(ExceptionContext filterContext)
                    {
                        if (filterContext.Exception.InnerException == null)
                        {
                            if (!filterContext.ExceptionHandled && filterContext.Exception is Exception)
                            {
                                filterContext.Result = new RedirectToRouteResult(
                                               new RouteValueDictionary 
                                               {
                                                   { "action", "Error" },
                                                   { "controller", "Home" }
                                               });
                                filterContext.ExceptionHandled = true;
                            }
                        }
                       
                    }
                }
            }
        
        
        //at controller
        
        using nullReference_Exception.Models;
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Web;
        using System.Web.Mvc;
        
        namespace nullReference_Exception.Controllers
        {
            [CustomException]  //on every controller 
            public class HomeController : Controller
            {
                public ActionResult Index()
                {
                    LoginViewModel aLog=null;
                    var a=aLog.Email;
                    return View();
                }
    
    //you don't need to declare this on every controller
    
                public ActionResult Error()
                {
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
            
        // now make a error action and view
    //read comment carefully
                                
