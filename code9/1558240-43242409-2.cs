    public UnsupportedContentTypeHandler()
    {
        supportedContentTypes = GlobalConfiguration.Configuration.Formatters
                                    .SelectMany(f => f.SupportedMediaTypes).ToArray();
    }
