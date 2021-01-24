    public class UrlRewriteMiddleware
    {
        private readonly RequestDelegate _next;
        public UrlRewriteMiddleware(RequestDelegate next)
        {
            _next = next;
        }
    
        public async Task Invoke(HttpContext context)
        {
                
            if (context.User.Identity.IsAuthenticated)
            {
                var route = context.GetRouteData();
                if (route.Values["controller"].ToString() == "ANYCONTROLLER" &&
                    route.Values["action"].ToString() == "ANYMETHOD")
                {
                    context.Request.Path = "/CONTROLLER2/METHOD2";
                }
            }
    
            await _next.Invoke(context);
        }
    }
