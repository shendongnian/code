    public class SomeRule: ActionFilterAttribute
    {
        // Any public properties here can be set within the declaration of the filter
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
    }
