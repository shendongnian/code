    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Hosting;
    
    namespace Web.Middlewares
    {
        public class OptionsMiddleware
        {
            private readonly RequestDelegate _next;
            private IHostingEnvironment _environment;
    
            public OptionsMiddleware(RequestDelegate next, IHostingEnvironment environment)
            {
                _next = next;
                _environment = environment;
            }
    
            public async Task Invoke(HttpContext context)
            {
                this.BeginInvoke(context);
                await this._next.Invoke(context);
            }
    
            private async void BeginInvoke(HttpContext context)
            {
                if (context.Request.Method == "OPTIONS")
                {
                    context.Response.Headers.Add("Access-Control-Allow-Origin", new[] { (string)context.Request.Headers["Origin"] });
                    context.Response.Headers.Add("Access-Control-Allow-Headers", new[] { "Origin, X-Requested-With, Content-Type, Accept" });
                    context.Response.Headers.Add("Access-Control-Allow-Methods", new[] { "GET, POST, PUT, DELETE, OPTIONS" });
                    context.Response.Headers.Add("Access-Control-Allow-Credentials", new[] { "true" });
                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsync("OK");
                }
            }
        }
    
        public static class OptionsMiddlewareExtensions
        {
            public static IApplicationBuilder UseOptions(this IApplicationBuilder builder)
            {
                return builder.UseMiddleware<OptionsMiddleware>();
            }
        }
    }
