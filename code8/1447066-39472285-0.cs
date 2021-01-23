     public class BaseController : Controller
     {
        protected override void OnException(ExceptionContext filterContext)
        {
            string redirectUrl;
            var exception = filterContext.Exception;
            if (exception is EntityException)
            {
                redirectUrl = "/Content/error.html";
            }
            else
            {
                redirectUrl = "/Info/Index";
            }
            //do whatever you wont
            Response.Redirect(redirectUrl);
        }
