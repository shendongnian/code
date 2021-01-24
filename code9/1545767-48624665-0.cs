    public class MyMiddleware
    {
        private readonly RequestDelegate _next;
    
        public MyMiddleware(RequestDelegate next)
        {
            _next = next;
        }
    
        public async Task Invoke(HttpContext httpContext, IImpersonatorRepo imperRepo)
        {
            imperRepo.MyProperty = 1000;
            await _next(httpContext);
        }
    }
