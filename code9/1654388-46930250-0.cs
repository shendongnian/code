        // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        //...
        // Add application services.
        services.AddTransient<IRepository, MemoryRepository>();
        //..
    }
