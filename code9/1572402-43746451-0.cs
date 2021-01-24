    public class SomeRuleAttribute : System.Web.Mvc.ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            // Define some condition to check here
            if (condition)
            {
                // Redirect the user accordingly
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Account" }, { "action", "LogOn" } });
            }
        }
    }
