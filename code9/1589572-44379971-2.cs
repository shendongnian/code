    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors(); // Make sure you call this previous to AddMvc
        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
    }
