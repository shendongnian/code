    namespace SwaggerDemo.Handlers
    {
        using System.Net;
        using System.Threading.Tasks;
    
        using Microsoft.AspNetCore.Builder;
        using Microsoft.AspNetCore.Http;
    
        public class RequestAuthHandler
        {
            private const string _swaggerPathIdentifier = "swagger";
            private readonly RequestDelegate _next;
    
            public RequestAuthHandler(RequestDelegate next)
            {
                _next = next;
            }
    
            public async Task Invoke(HttpContext context)
            {
                // First check if the current path is the swagger path
                if (context.Request.Path.HasValue && context.Request.Path.Value.ToLower().Contains(_swaggerPathIdentifier))
                {
                    // Secondly check if the current user is authenticated
                    if (!context.User.Identity.IsAuthenticated)
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        return;
                    }
                }
                await _next.Invoke(context);
            }
        }
    
        public static class RequestAuthHandlerExtension
        {
            public static IApplicationBuilder UseRequestAuthHandler(this IApplicationBuilder builder)
            {
                return builder.UseMiddleware<RequestAuthHandler>();
            }
        }
    }
