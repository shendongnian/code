    public class AreaRouter : MvcRouteHandler, IRouter
    {
        public new async Task RouteAsync(RouteContext context)
        {
            string url = context.HttpContext.Request.Headers["HOST"]; 
            var splittedUrl = url.Split('.');
            if (splittedUrl.Length > 0 && splittedUrl[0] == "admin")
            {
                context.RouteData.Values.Add("area", "Admin");
            }
            await base.RouteAsync(context);
        }
    }
