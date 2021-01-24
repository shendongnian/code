    app.UseMvc(routes =>
    {
        routes.MapRoute(
            "Logged",
            "SomeUrl",
            new {controller = "Default", action = "Index"},
            new {controller = new MustBeLoggedIn()}
        );
        routes.MapRoute(
            "NotLogged",
            "SomeUrl",
            new { controller = "Auth", action = "Index" }
        );
        routes.MapRoute(
            name: "default",
            template: "{controller=Home}/{action=Index}");
    });
    public class MustBeLoggedIn : IRouteConstraint
    {
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            return httpContext.User?.Identity?.IsAuthenticated ?? false;
        }
    }
