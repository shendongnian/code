        public void Register(HttpConfiguration config)
        {
            config.MapODataServiceRoute
            (
                "odata",
                "odata",
                BuildRoute
            );
        }
        private void BuildRoute(IContainerBuilder builder)
        {
            builder
                .AddService(ServiceLifetime.Singleton, s => BuildEdmModelForOData())
                .AddService<ODataSerializerProvider>(ServiceLifetime.Singleton, s => new MyODataSerializerProvider(s));
        }
        public IEdmModel BuildEdmModelForOData()
        {
            ODataConventionModelBuilder
                builder = new ODataConventionModelBuilder();
            // Build model here
            return builder.GetEdmModel();
        }
