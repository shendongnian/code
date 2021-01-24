        context.MapRoute(
                        name: "product",
                        url: "xyz/er/{*slug}",
                        defaults: new { controller = "er", action = "Index", slug = UrlParameter.Optional },
     constraints: new { productname= new ProductNameConstraint() }
                         );
    
    
    public class ProductNameConstraint: IRouteConstraint
            {
                public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
                {
                    //logic here
                }
            }
