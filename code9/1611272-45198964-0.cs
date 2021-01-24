    public class HandleUnauthorizedAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
    
            if (filterContext.Exception.GetType() != typeof (SecurityException)) return;
    
            var controllerName = (string) filterContext.RouteData.Values["controller"];
            var actionName = (string) filterContext.RouteData.Values["action"];
            var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);
    
            filterContext.Result = new ViewResult
            {
                ViewName = "Unauthorized",
                ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                TempData = filterContext.Controller.TempData
            };
            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = 403;
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
        }
    }
