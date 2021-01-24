    using AspNetCore.RouteAnalyzer; // Add
    .....
    public void ConfigureServices(IServiceCollection services)
    {
        ....
        services.AddRouteAnalyzer(); // Add
    }
    
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        ....
        app.UseMvc(routes =>
        {
            routes.MapRouteAnalyzer("/routes"); // Add
            ....
        });
    }
