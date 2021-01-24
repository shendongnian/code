    public void ConfigureServices(IServiceCollection services) {
        // add conventions here
        services.AddMvc().AddWebApiConventions();                
    }
    public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
        app.UseMvc(routes => {
            // map one global route
            routes.MapWebApiRoute("WebApi", "api/{controller}");
        });
    }
