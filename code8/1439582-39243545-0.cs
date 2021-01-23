    [Filter1, Filter2, MyErrorFilter]
        public class HomeController : Controller
        {
            public ActionResult Index()
            {
                //throw new Exception("Poda!");
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
    
        public class Filter1 : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                Console.WriteLine("filter1-action executing!!");
                base.OnActionExecuting(filterContext);
            }
    
            public override void OnActionExecuted(ActionExecutedContext filterContext)
            {
                Console.WriteLine("filter1-action executed!!!");
                base.OnActionExecuted(filterContext);
            }
        }
    
        public class Filter2: ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                Console.WriteLine("filter2-action executing!!!");
                throw new Exception("poda!!1");
                base.OnActionExecuting(filterContext);
            }
    
            public override void OnActionExecuted(ActionExecutedContext filterContext)
            {
                Console.WriteLine("filter2-action executed!!!");
                base.OnActionExecuted(filterContext);
            }
        }
    
        public class MyErrorFilter : HandleErrorAttribute
        {
            public override void OnException(ExceptionContext filterContext)
            {
                Console.WriteLine("an exception captured!!!");
                base.OnException(filterContext);
            }
        }
