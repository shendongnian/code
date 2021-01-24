    public class ModuleNotInstalledConstraint : IRouteConstraint
    {
        public bool Match(
            HttpContextBase httpContext, 
            Route route, 
            string parameterName, 
            RouteValueDictionary values, 
            RouteDirection routeDirection)
        {
            if (module is installed)
            {
                return false;
            }
            
            return true;
        }
    }
