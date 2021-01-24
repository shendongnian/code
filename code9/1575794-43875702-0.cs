    public class ContentURLConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values routeDirection)
        {
            var url = values[parameterName] as string;
            if (!string.IsNullOrEmpty(url))
            {
                return url.Contains("comm");
            }
            return false; // or true, depending on what you need.
        }
    }
