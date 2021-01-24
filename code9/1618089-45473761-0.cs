    public class ExtractRouteValueResourceFilter : IAsyncResourceFilter {
        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next) {
            var value = context.RouteData.Values["key"];
            if (value != null) {
                context.HttpContext.Items["key"] = value;
            }
            await next();
        }
    }
