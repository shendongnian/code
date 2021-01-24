        private class ApplyDocumentVendorExtensions : IDocumentFilter
        {
            public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
            {
                schemaRegistry.GetOrRegister(typeof(ExtraType));
                schemaRegistry.GetOrRegister(typeof(BigClass));                
            }
        }
