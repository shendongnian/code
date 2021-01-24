    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class ValidateViewModelAttribute : Attribute, IFilterFactory
    {
        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            var logger = serviceProvider.GetService<ILogger>();
            return new InternalValidateModel(logger);
        }
        private class InternalValidateModel : IActionFilter
        {
            private ILogger _log;
            public InternalValidateModel(ILogger log)
            {
                _log = log;
            }
            public void OnActionExecuting(ActionExecutingContext context)
            {
                if (IsInvalidModelState(context))
                {
                    _log.Information("Invalid ModelState: {Model}", context.ModelState.ErrorMessages());
                    context.Result = new BadRequestObjectResult(context.ModelState);
                }
            }
            public void OnActionExecuted(ActionExecutedContext context)
            {
            }
            private bool IsInvalidModelState(ActionExecutingContext context)
            {
                var method = context.HttpContext.Request.Method;
                return (method == "POST" ||
                        method == "PUT") &&
                       !context.ModelState.IsValid;
            }
        }
        public bool IsReusable => true;
    }
