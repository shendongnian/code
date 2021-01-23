    /*
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    Made available under the Apache 2.0 license.
    https://www.apache.org/licenses/LICENSE-2.0
    */
    
    /// <summary>
    /// Sets response headers for static files having certain media types.
    /// In Startup.Configure, enable before UseStaticFiles with 
    /// app.UseMiddleware<CorsResponseHeaderMiddleware>();
    /// </summary>
    public class CorsResponseHeaderMiddleware
    {
        private readonly RequestDelegate _next;
        // Must NOT have trailing slash
        private readonly string AllowedOrigin = "http://server:port";
        
        private bool IsCorsOkContentType(string fieldValue)
        {
            var fieldValueLower = fieldValue.ToLower();
            // Add other media types here.
            return (fieldValueLower.StartsWith("application/javascript"));
        }
        public CorsResponseHeaderMiddleware(RequestDelegate next) {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            context.Response.OnStarting(ignored =>
            {
                if (context.Response.StatusCode < 400 &&
                    IsCorsOkContentType(context.Response.ContentType))
                {
                    context.Response.Headers.Add("Access-Control-Allow-Origin", AllowedOrigin);
                }
                return Task.FromResult(0);
            }, null);
            await _next(context);
        }
    }
