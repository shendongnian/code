    public class LogActionAttribute : FilterAttribute, IActionFilter 
    { 
        public void OnActionExecuted(ActionExecutedContext filterContext) 
        { 
            // log something about the action...
        }
        public void OnActionExecuting(ActionExecutingContext filterContext) 
        { 
        } 
    }
    public class HomeController : Controller
    {
        [LogAction]
        public ActionResult Index()
        {
            return View();
        }
    }
