    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        routes.MapRoute(
            name: "TokenRoute",
            url: "{token}",
            defaults: new { controller = "Home", action = "Index" },
            constraints: new { token = new TokenConstraint() }
        );
        routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
        );
    }
    public class TokenConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if ((string)values[parameterName] == "MyToken")
            {
                return true;
            }
            return false;
        }
    }
