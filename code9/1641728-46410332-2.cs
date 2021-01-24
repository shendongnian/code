    public class RequestTimestampMiddleware
    {
        private readonly RequestDelegate _next;
    
        public RequestTimestampMiddleware(RequestDelegate next)
        {
            _next = next;
        }
    
        public Task Invoke(HttpContext context)
        {
            context.Items.Add("RequestStartedOn", DateTime.UtcNow);
    
            // Call the next delegate/middleware in the pipeline
            return this._next(context);
        }
    }
