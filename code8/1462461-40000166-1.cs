    protected void Application_Start() {
        // ...
        var metaDataProvider = new CustomModelMetaDataProvider();
        ModelMetadataProviders.Current = metaDataProvider;
    }
