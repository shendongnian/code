    public class SlugConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName,
                           RouteValueDictionary values, RouteDirection routeDirection)
        {
            var asm = Assembly.GetExecutingAssembly();
            //Get all the controller names
            var controllerTypes = (from t in asm.GetExportedTypes()
                                   where typeof(IController).IsAssignableFrom(t)
                                   select t.Name.Replace("Controller", ""));
            var slug = values["slug"];
            if (slug != null)
            {
               
                if (controllerTypes.Any(x => x.Equals(slug.ToString(),
                                                          StringComparison.OrdinalIgnoreCase)))
                {
                    return false;
                }
                else
                {
                    var c = slug.ToString().Split('/');
                    if (c.Any())
                    {
                        var firstPart = c[0];
                        if (controllerTypes.Any(x => x.Equals(firstPart, 
                                StringComparison.OrdinalIgnoreCase)))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            return false;
        }
    }
