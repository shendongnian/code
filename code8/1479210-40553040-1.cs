    using System.Web;
    using System.Web.Routing;
    public class IsNotDashboard : IRouteConstraint
    {
        public IsNotDashboard()
        {
        }
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            string controller = values["controller"].ToString().ToLower();
            
            return controller != "dashboard";
        }
    }
