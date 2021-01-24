    public class MyAccessAttribute : Attribute, IActionFilter{
        
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (condition)
                context.Result = new new UnauthorizedResult();
        }
        
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
