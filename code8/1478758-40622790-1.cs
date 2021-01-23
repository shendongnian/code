    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IAntiforgery antiforgery)
    {
        ...
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAntiforgery();
        ...
