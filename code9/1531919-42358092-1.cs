    public class ValidationFilterAttribute : ActionFilterAttribute, IExceptionFilter
    {
    
        public void OnException(ExceptionContext context)
        {
            // only handle ValidationException
            var ex = context.Exception as ValidationException;
            if (ex == null) return;
    
            // re-render get action's view, or redirect to get action
            var result = new ViewResult { ViewName = "GetView" }
            context.HttpContext.Response.Clear();
            context.Result = result;
        }
    
    }
