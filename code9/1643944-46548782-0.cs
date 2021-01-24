     public class UserActivityFilter : ActionFilterAttribute, IActionFilter
        {
    
            void IActionFilter.OnActionExecuting(ActionExecutingContext actionExecutedContext)
            {
                Log(actionExecutedContext);
                base.OnActionExecuting(actionExecutedContext);
            }
    
            private void Log(ActionExecutingContext filterContext)
            {
                //Your logic log here
            }
        }
