    public sealed class PrivateCacheControlResultFilterAttribute : Attribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
        }
        public void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.OnStarting(state =>
            {
                var httpContext = ((ResultExecutingContext)state).HttpContext;
                if (httpContext.Response.StatusCode == 200)
                    httpContext.Response.GetTypedHeaders().CacheControl = new CacheControlHeaderValue
                    {
                        Private = true,
                        MaxAge = TimeSpan.FromSeconds(1200)
                    };
                return Task.CompletedTask;
            }, context);
        }
    }
