    GlobalConfiguration.Configuration.MessageHandlers.Add(new SwaggerAccessMessageHandler());
    
    GlobalConfiguration.Configuration.EnableSwagger(c =>
    {
        ...
    });
