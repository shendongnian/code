    GlobalConfiguration.Configure(config =>
    {
        config.Services.Replace(typeof(IHttpControllerTypeResolver), new DefaultHttpControllerTypeResolver());
        ...
    });
