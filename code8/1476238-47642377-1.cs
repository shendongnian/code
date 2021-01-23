    public class RootRouteConstraint<T> : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            var rootMethodNames = typeof(T).GetMethods().Select(x => x.Name.ToLower());
            return rootMethodNames.Contains(values["action"].ToString().ToLower());
        }
    }
