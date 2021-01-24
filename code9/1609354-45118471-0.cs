    public static void RegisterRoutes(RouteCollection routes)
            {
                routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    
                routes.MapRoute(
                  name: "DefaultLocalized",
                  url: "{language}/{controller}/{action}/{id}",
                  defaults: new
                  {
                      controller = "Home",
                      action = "Index",
                      id = UrlParameter.Optional,
                      language = "en-US"
    
                  }
                      );
             }
