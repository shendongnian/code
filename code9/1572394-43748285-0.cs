    public class SessionConstraint : IRouteConstraint
    {
        public bool Match
            (
                HttpContextBase httpContext, 
                Route route, 
                string parameterName, 
                RouteValueDictionary values, 
                RouteDirection routeDirection
            )
        {
            return Session["Foo"]; // value in session is true/false
                                   // or use some other expression that is true/false
        }
    }
