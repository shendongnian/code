        using Microsoft.AspNetCore.Builder;    // for IApplicationBuilder
        namespace myApp.Middleware
        {
           public static class MiddlewareExtensions  
        {
           public static IApplicationBuilder UseRequestHeaderMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestHeaderMiddleware>();
        }
        ... here you can define others
       }
      }
