    using System.Web.Mvc;
    using System.Web.Routing;
    using Umbraco.Core;
    
        public class RoutingHandler : ApplicationEventHandler
        {
            protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
            {
                RegisterCustomRoutes();
            }
        
            private static void RegisterCustomRoutes()
            {
                RouteTable.Routes.MapRoute(
                    name: "ProductDetails",
                    url: "products/details",
                    defaults: new { controller = "ProductDetails", action = "Index" }
                );
            }
        }
