    public class ConfiguredAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (MvcApplication.IsConfigured) return;
            filterContext.Result = new ViewResult
            {
                ViewName = "Offline",
                TempData = filterContext.Controller.TempData
            };
        }
    }
