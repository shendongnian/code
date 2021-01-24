    namespace ApplicaAccWeb.Validators
    {
     
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class LockScreenAttribute : ActionFilterAttribute, IActionFilter
    {
        public static int countLockScreen;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
       /// This is a new Code--------------------------------
                bool skipImportantTaskFilter = filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(SkipImportantTaskAttribute), true) ||
                    filterContext.ActionDescriptor.IsDefined(typeof(SkipImportantTaskAttribute), true);
                if (!skipImportantTaskFilter)
                {
                    PerformModelAlteration(filterContext);
                }
                
            }
         ////----------------------------------------------
        }
         ////Only entering here if Bool is true------------------------
        private void PerformModelAlteration(ActionExecutingContext filterContext)
        {
            try
            {
                var lockScreen = filterContext.HttpContext.Session["lockScreen"];
                if ((string)lockScreen == "Lock")
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(
                    new { controller = "Account", action = "LockScreen" }));
                }
                base.OnActionExecuting(filterContext);
            }
            catch (Exception)
            {
            }
        }
    }
