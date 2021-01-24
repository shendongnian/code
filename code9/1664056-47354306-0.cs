    public class ExceptionFilter : IExceptionFilter, IActionFilter
    {
        private IDictionary<string, object> _actionArguments;
    
        public void OnException(ExceptionContext context)
        {
            _actionArguments // great success!
        }
    
        public void OnActionExecuting(ActionExecutingContext context)
        {
            _actionArguments = context.ActionArguments;
        }
    
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // do nothing
        }
    }
