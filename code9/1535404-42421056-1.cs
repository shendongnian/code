    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapODataServiceRoute("odata", null, GetEdmModel(), new DefaultODataBatchHandler(GlobalConfiguration.DefaultServer));
            config.EnsureInitialized();
        }
    
        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.Namespace = "YourNamespace";
            builder.ContainerName = "DefaultContainer";
            builder.EntitySet<Person>("People");
            builder.EntitySet<Account>("Accounts");
            var edmModel = builder.GetEdmModel();
            return edmModel;
        }
    }
