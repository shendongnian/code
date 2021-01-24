    public class FooMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly PathString _path;
        public FooMiddleware(RequestDelegate next, PathString path)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            if (!context.Request.Path.StartsWithSegments(path))
            {
                // jump to the next middleware
                await _next.Invoke(context);
            }
            // do your stuff
        }
    }
