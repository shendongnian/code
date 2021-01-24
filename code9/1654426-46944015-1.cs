    public void Process(PipelineArgs args) {
        GlobalConfiguration.Configure(config => {
            // Map Attribute Routes
            config.MapHttpAttributeRoutes();
            // Map Convention-based Routes
            config.Routes.MapHttpRoute(
                name: "myApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            // Replace IHttpControllerSelector with our custom implementation
            ReplaceControllerSelector(config);
        });
    }
