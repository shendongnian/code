    public void ConfigureServices(IServiceCollection services)
    {
        // Wire up whatever your equivalent DbContext class is here
        services.AddDbContext<ApplicationDbContext>();
    }
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            scope.ServiceProvider.GetService<ApplicationDbContext>().Database.Migrate();
        }
    }
