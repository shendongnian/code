    public class RequestBodyStoringMiddleware
    {
        private readonly RequestDelegate _next;
        public RequestBodyStoringMiddleware(RequestDelegate next) =>
            _next = next;
        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Request.EnableBuffering();
            string body;
            using (var streamReader = new System.IO.StreamReader(
                httpContext.Request.Body, System.Text.Encoding.UTF8, leaveOpen: true))
                body = await streamReader.ReadToEndAsync();
            httpContext.Request.Body.Position = 0;
            httpContext.Items["body"] = body;
            await _next(httpContext);
        }
    }
To use this, do a `app.UseMiddleware<RequestBodyStoringMiddleware>();` *as early as possible* in `Startup.Configure`; the issue is that depending on what else you're doing, the body stream might end up being consumed along the way, so the order matters. Then, when you need the body later (in the controller, or another piece of middleware), access it through `(string)HttpContext.Items["body"];`. Yes, your controllers now rely on implementation details of your configuration but what can you do.
