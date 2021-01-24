    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            System.Web.Routing.RouteTable.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //add the handler class in WebApiConfig
            config.MessageHandlers.Add(new APIKeyHandler());
        }
    }
