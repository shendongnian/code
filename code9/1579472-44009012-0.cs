    HttpConfiguration Config = new HttpConfiguration();
    WebApiConfig.Register(Config);
    Config.EnableSwagger((c) =>
    {
        c.SingleApiVersion("v1", "Flynn Forms");
        c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
    }).EnableSwaggerUi();
    app.UseWebApi(Config);
