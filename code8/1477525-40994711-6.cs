    public sealed class BodyRewindMiddleware
    {
        private readonly RequestDelegate _next;
        public BodyRewindMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try { context.Request.EnableRewind(); } catch { }
            await _next(context);
            // context.Request.Body.Dipose() might be added to release memory, not tested
        }
    }
    public static class BodyRewindExtensions
    {
        public static IApplicationBuilder EnableRequestBodyRewind(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }
            return app.UseMiddleware<BodyRewindMiddleware>();
        }
    }
