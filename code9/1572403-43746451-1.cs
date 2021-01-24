    public class SomeRule: ActionFilterAttribute
    {
        public string YourProperty { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        base.OnActionExecuting(filterContext);
        // Define some condition to check here
        if (condition && YourProperty == "some value")
        {
            // Redirect the user accordingly
            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Account" }, { "action", "LogOn" } });
        }
    }
