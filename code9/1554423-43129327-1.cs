    public class UIExceptionHandler
    {
        RequestDelegate _next;
        public UIExceptionHandler(RequestDelegate next)
        {
            this._next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await this._next(context);
            }
            catch (Exception x)
            {
                if (!context.Response.HasStarted)
                {
                    context.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                    context.Response.Headers["Message"] = x.Message;
                }
            }
        }
    }
    public static class UIExcetionHandlerExtensions
    {
        public static IApplicationBuilder UseUIExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UIExceptionHandler>();
        }
    }
