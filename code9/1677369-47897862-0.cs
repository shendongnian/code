    public class UserMvcController : Controller
    {
       protected override void OnException(ExceptionContext filterContext)
       {
          filterContext.ExceptionHandled = true;
    
          //Redirect or return a view, but not both.
          filterContext.Result = RedirectToAction("Index", "ErrorHandler");
          // OR 
          filterContext.Result = new ViewResult
          {
             ViewName = "~/Views/ErrorHandler/Index.cshtml"
          };
       }
    }
