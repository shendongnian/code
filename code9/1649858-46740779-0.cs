    public class YourActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
        
        }
    }
    
    
         [YourActionFilter]
         public class HomeController : Controller
         {
              public ActionResult Index()
              {
                   return View();
              }
    
              public ActionResult About()
              {
                   return View();
              }
         }
