    public void Configuration(IAppBuilder appBuilder)
            {
                // Set up server configuration
                var config = new HttpConfiguration();
                config.Routes.MapODataRoute(routeName: "OData", routePrefix: "odata", model: GetEdmModel());
                appBuilder.UseWebApi(config);
            }
    
            private IEdmModel GetEdmModel()
            {
                var modelBuilder = new ODataConventionModelBuilder();
                modelBuilder.EntitySet<Customer>("customer");
                modelBuilder.EntitySet<Order>("order");
                modelBuilder.EntitySet<Customer>("response");
                return modelBuilder.GetEdmModel();
            }
