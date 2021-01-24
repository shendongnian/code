    // this filter attribute is selectively applied to controllers or actions 
    // in order to suppress LoggingActionFilter from logging the request
    public class SuppressLoggingAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // this will put "suppress" indicator on HttpContext of the current request
            LoggingActionFilter.Suppress(context.HttpContext);
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
