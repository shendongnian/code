    public class ApiVersion1RoutePrefixAttribute : RoutePrefixAttribute
        {
            private const string RouteBase = "api/{apiVersion:apiVersionConstraint(v1)}";
            private const string PrefixRouteBase = RouteBase + "/";
    
            public ApiVersion1RoutePrefixAttribute(string routePrefix)
                : base(string.IsNullOrWhiteSpace(routePrefix) ? RouteBase : PrefixRouteBase + routePrefix)
            {
            }
        }
     public class ApiVersion2RoutePrefixAttribute : RoutePrefixAttribute
            {
                private const string RouteBase = "api/{apiVersion:apiVersionConstraint(v2)}";
                private const string PrefixRouteBase = RouteBase + "/";
        
                public ApiVersion1RoutePrefixAttribute(string routePrefix)
                    : base(string.IsNullOrWhiteSpace(routePrefix) ? RouteBase : PrefixRouteBase + routePrefix)
                {
                }
            }
