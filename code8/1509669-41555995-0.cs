    This is a trivial example so improve/adjust as necessary:
    Filter:
        using System.Net;
        using System.Web.Mvc;
        public class PrivatizeFilter : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                //This trivial example redirects to home page/root of app
                filterContext.HttpContext.Response.Headers.Add("Location", "/");
                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Moved);
            }
        }
    Decorate the Controller with the above filter:
        [PrivatizeFilter]
        public class HelpController : Controller
        {
           ......
