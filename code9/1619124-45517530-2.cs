    //Startup.cs
    public void ConfigureServices(IServiceCollection services){
        services.AddMvc();
        services.AddScoped<IDocumentService, DocumentServiceClient>();
        services.AddScoped<ILogic, Logic>();
    }
