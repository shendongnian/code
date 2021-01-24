    internal class HomeControllerConstraint : IRouteConstraint
    {
        private static readonly Lazy<HashSet<string>> homeMethods = new Lazy<HashSet<string>>(CreateHomeMethods);
        private static HashSet<string> CreateHomeMethods()
        {
            return typeof(HomeController).GetMethods().Select(e => e.Name.ToLower()).ToSet();
        }
        public static bool Exists(string name)
        {
            return homeMethods.Value.Contains(name.Trim().ToLower());
        }
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            return homeMethods.Value.Contains(values["action"].ToString().ToLower());
        }
    }
