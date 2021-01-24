    public override IServiceProvider ConfigureServices(IServiceCollection services)
    {
        services.AddProjectSpecificStuff();
        ITraceWriter traceWriter = null;
        services.AddMvc().AddJsonOptions(options =>
        {
            ...
            // other options here
        });
        return base.ConfigureServices(services);
    }
    
    public void Configure(IApplicationBuilder app, ITraceWriter traceWriter, IOptions<MvcJsonOptions> jsonOptions)
    {
        services.AddMvc().AddJsonOptions(options =>
        {
            options.SerializerSettings.TraceWriter = provider.GetService<ITraceWriter>();
        });
    }
