    public class RedirectAfterActionFilter : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // Your decision logic
            if (filterContext.HttpContext.Request.UrlReferrer.AbsolutePath == "something usefull")
            {
                filterContext.Result = new RedirectToRouteResult("Your Route Name", routeValues: null); // redirect to Home
            }
            base.OnActionExecuted(filterContext);
        }
    }
