    public class MyAccessAttribute : Attribute, IActionFilter{
        
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!CheckAccessCondition())
            {
                context.Result = new new UnauthorizedResult();
            }
        }
        
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
