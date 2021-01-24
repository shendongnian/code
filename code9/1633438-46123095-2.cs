    using Site.Services;
    using System;
    using System.Web.Http;
    
    namespace Site
    {
        public static class WebApiConfig
        {
            public static void Register(HttpConfiguration config)
            {
                config.BindParameter(typeof(DateTime), new DateTimeModelBinder());
                config.BindParameter(typeof(DateTime?), new DateTimeModelBinder());
    
                //Rest of my code
                config.MapHttpAttributeRoutes();
    
                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{action}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );
            }
        }
    }
