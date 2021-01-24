    public void ConfigureServices(IServiceCollection services)
    {
      services.AddApi(Configuration.GetSection("Database"));
      services.AddMvc();
    }
