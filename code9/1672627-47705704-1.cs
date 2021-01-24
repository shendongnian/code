    public void ConfigureServices(IServiceCollection Services)
    {
        Services.AddMvc();
        // Configure dependency injection.
        Services.AddSingleton(typeof(AppSettings), WindowsService.AppSettings);
        Services.AddSingleton(typeof(ICoreLogger), WindowsService.Logger);
    }
