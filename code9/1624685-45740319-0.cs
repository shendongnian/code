    public class BaseController : Controller
    {                
        protected override void OnException(ExceptionContext filterContext)
        {
            // verify which kind of exception it is and do somethig like logging
        }
    }
