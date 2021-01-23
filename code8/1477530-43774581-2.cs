    using Microsoft.AspNetCore.Http.Internal;
    [...]
    public class EnableRequestRewindMiddleware
    {
        private readonly RequestDelegate _next;
    
        public EnableRequestRewindMiddleware(RequestDelegate next)
        {
            _next = next;
        }
    
        public async Task Invoke(HttpContext context)
        {
            context.Request.EnableRewind();
            await _next(context);
        }
    }
    
    public static class EnableRequestRewindExtension
    {
        public static IApplicationBuilder UseEnableRequestRewind(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<EnableRequestRewindMiddleware>();
        }
    }
