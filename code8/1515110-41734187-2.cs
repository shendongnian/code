    public void ConfigureServices(IServiceCollection services)
    {
         services.AddMemoryCache();
         services.AddSession();
         services.AddMvc();
    }
