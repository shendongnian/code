    public class AppHost : AppHostBase
    {
        public override RouteAttribute[] GetRouteAttributes(Type requestType)
        {
            var routes = base.GetRouteAttributes(requestType);
            routes.Each(x => x.Path = x.Path.ToLower(CultureInfo.GetCultureInfo("en-US")));
            return routes;
        }
    }
