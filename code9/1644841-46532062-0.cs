    public class BaseController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            //your existing code to log errors here
            filterContext.ExceptionHandled = true;
            if (filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                filterContext.Result = new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new
                    {
                        Error = true,
                        Message = filterContext.Exception.Message
                    }
                };
                filterContext.HttpContext.Response.StatusCode = 500;
                filterContext.ExceptionHandled = true;
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                    {{"controller", "Error"}, {"action", "Index"}});
            }
        }
    }
