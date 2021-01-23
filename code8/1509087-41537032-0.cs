    public static void Register(HttpConfiguration config) {
        config.MapHttpAttributeRoutes();
        config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{action}/{studentName}"
        );
    }
