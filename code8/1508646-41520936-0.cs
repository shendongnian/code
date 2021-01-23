    public static class HelloRouterExtensions {
    
        public static IApplicationBuilder UseHelloRouter(this IApplicationBuilder app) {
            var trackPackageRouteHandler = new RouteHandler(context => {
                var routeValues = context.GetRouteData().Values;
                return context.Response.WriteAsync(
                    $"Hello! Route values: {string.Join(", ", routeValues)}");
            });
        
            var routeBuilder = new RouteBuilder(app, trackPackageRouteHandler);
        
            routeBuilder.MapRoute(
                "Track Package Route",
                "package/{operation:regex(^track|create|detonate$)}/{id:int}");
        
            routeBuilder.MapGet("hello/{name}", context => {
                var name = context.GetRouteValue("name");
                // This is the route handler when HTTP GET "hello/<anything>"  matches
                // To match HTTP GET "hello/<anything>/<anything>,
                // use routeBuilder.MapGet("hello/{*name}"
                return context.Response.WriteAsync($"Hi, {name}!");
            });
        
            var routes = routeBuilder.Build();
            app.UseRouter(routes);
            return app;
        }
    }
