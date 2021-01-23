        // used in your WebApiConfig class
        config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{namespace}/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
        );
        config.Services.Replace(typeof(IHttpControllerSelector), new NamespaceHttpControllerSelector(config));
