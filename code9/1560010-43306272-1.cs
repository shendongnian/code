    public class HandleLoginAttribute : Attribute, IActionFilter, IResultFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null) {
                // Handle exceptions thrown at controller level
            }
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
        public void OnResultExecuted(ResultExecutedContext context)
        {
            if (context.Exception != null)
            {
                // Handle exceptions thrown when rendering the view
            }
        }
        public void OnResultExecuting(ResultExecutingContext context)
        {
           
        }
    }    
