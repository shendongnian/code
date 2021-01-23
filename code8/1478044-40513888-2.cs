    public class AreaRouter : MvcRouteHandler, IRouter
    {
        public new async Task RouteAsync(RouteContext context)
        {
            string url = context.HttpContext.Request.Headers["HOST"];
 
            string subdomain= url.Split('.')[0];
            string area = char.ToUpper(subdomain[0]) + subdomain.Substring(1);
 
            context.RouteData.Values.Add("area", area );
 
            await base.RouteAsync(context);
        }
    }
