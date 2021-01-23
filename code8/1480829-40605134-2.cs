    public class EndRequestMiddleware
    {
        private readonly RequestDelegate _next;
    
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
    
        public async Task Invoke(HttpContext context)
        {
            // Do tasks before other middleware here, aka 'BeginRequest'
            // ...
    
            // Let the middleware pipeline run
            await _next(context);
    
            // Do tasks after middleware here, aka 'EndRequest'
            // ...
        }
    }
