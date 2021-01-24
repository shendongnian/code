    public class ProductConstraint : IRouteConstraint
        {
            public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
            {
               return !Assembly.GetAssembly(typeof(MvcApplication))
                    .GetTypes().Where(type => typeof(Controller).IsAssignableFrom(type))
                    .Any(c => c.Name.Replace("Controller", "") == values[parameterName].ToString());
            }
        }
