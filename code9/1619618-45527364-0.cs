    public IServiceProvider ConfigureServices(IServiceCollection services) {
        services.AddOptions();
        services.AddDbContext<Data.GenericDbContext>(options => options.UseSqlServer(this.ConnectionString));
        services.AddMvc();
        // Build the intermediate service provider
        var serviceProvider = services.BuildServiceProvider();
        //return the provider
        return serviceProvider;
    }
    public void Configure(IApplicationBuilder app, IHostingEnvironment env,
                          ILoggerFactory loggerFactory, IServiceProvider serviceProvider) {
        //...Other code removed for brevity
        var context = serviceProvider.GetService<Data.GenericDbContext>();
        Data.Debug.Init.Initalize(context, env);
    }
