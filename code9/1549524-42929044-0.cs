    public class MyMiddleware
        {
            private readonly RequestDelegate _next;
            
    
            public MyMiddleware(RequestDelegate next)
            {
                _next = next;
            }
    
            public async Task Invoke(HttpContext context)
            {
                //do your checkings
                await _next(context);
            }
    }
