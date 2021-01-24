    // adapted from /a/11911917/
    public class CustomRouteConstraint : IRouteConstraint
    {
        public CustomRouteConstraint(Regex regex)
        {
            this.Regex = regex;
        }
        public CustomRouteConstraint(string pattern) : this(new Regex("^(" + pattern + ")$", RegexOptions.CultureInvariant | RegexOptions.Compiled | RegexOptions.IgnoreCase)) 
        {
        }
 
        public Regex Regex { get; set; }
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (routeDirection == RouteDirection.IncomingRequest && parameterName == "id")
            {
                if (values["id"] == UrlParameter.Optional)
                     return true;
                if (this.Regex.IsMatch(values["id"].ToString()))
                     return true;
                // checking if 'id' parameter is exactly valid integer
                int id;
                if (int.TryParse(values["id"].ToString(), out id))
                     return true;
            }
            return false;
        }
    }
