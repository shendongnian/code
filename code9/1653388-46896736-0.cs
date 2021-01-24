    private class ApplyDocumentVendorExtensions : IDocumentFilter
    {
        public void Apply(SwaggerDocument sd, SchemaRegistry sr, IApiExplorer ae)
        {
            sr.GetOrRegister(typeof(ExtraType));
            //sr.GetOrRegister(typeof(BigClass));        
        }
    }
