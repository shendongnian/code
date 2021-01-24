    /// <summary>
    /// <see cref="https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/filters#Dependency injection"/>
    /// </summary>
    public class AutoLogAttribute : TypeFilterAttribute
        {
            public AutoLogAttribute() : base(typeof(AutoLogActionFilterImpl))
            {
    
            }
    
            private class AutoLogActionFilterImpl : IActionFilter
            {
                private readonly ILogger _logger;
                public AutoLogActionFilterImpl(ILoggerFactory loggerFactory)
                {
                    _logger = loggerFactory.CreateLogger<AutoLogAttribute>();
                }
    
                public void OnActionExecuting(ActionExecutingContext context)
                {
                    // perform some business logic work
                }
    
                public void OnActionExecuted(ActionExecutedContext context)
                {
                    //TODO: log body content and response as well
                    _logger.LogDebug($"path: {context.HttpContext.Request.Path}"); 
                }
            }
        }
