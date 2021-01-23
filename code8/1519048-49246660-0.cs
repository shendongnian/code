    namespace Test
    {
        public sealed class ModelStateCheckFilter : IActionFilter
        {
            public void OnActionExecuted(ActionExecutedContext context) { }
    
            public void OnActionExecuting(ActionExecutingContext context)
            {
                if (!context.ModelState.IsValid)
                {
                    context.Result = new BadRequestObjectResult(context.ModelState);
                }
            }
        }
    }
