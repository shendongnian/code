         using Microsoft.AspNetCore.Http;
         using System.Threading.Tasks;
     
         namespace myApp.Middleware
         {
         public class RequestHeaderMiddleware  
         {
         private readonly RequestDelegate _next;
         public RequestHeaderMiddleware(RequestDelegate next)
         {
             _next = next;
         }
    
        public async Task Invoke(HttpContext context)
        {
            string url = context.Request.Path;
    
            if (url.Contains("api") && !context.Request.Headers.Keys.Contains("user-key"))
            {
                context.Response.StatusCode = 400; //Bad Request                
                await context.Response.WriteAsync("You need a user key to be able to access this API..");
                return;
            }
            else
                {
                    if(context.Request.Headers["user-key"] != "28236d8ec201df516d0f6472d516d72d")
                    {
                        context.Response.StatusCode = 401; //UnAuthorized
                        await context.Response.WriteAsync("Invalid User Key");
                        return;
                    }
                }
    
            await _next.Invoke(context);
           }
          }
         } 
