    public void ConfigureServices(IServiceCollection services)
    {
        // Your stuff...
        services.AddOData();
        // Your stuff...
    }
    
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        // Your stuff...
        var provider = app.ApplicationServices.GetRequiredService<IAssemblyProvider>();
        var model = GetEdmModel(provider);
        app.UseMvc(builder => builder
            .MapODataRoute("odata", model)
            .MapRoute("default", "api/{controller}/{id?}"));
    }
    private static IEdmModel GetEdmModel(IAssemblyProvider assemblyProvider)
    {
        var builder = new ODataConventionModelBuilder(assemblyProvider);
        builder.EntitySet<Product>("Products");
        return builder.GetEdmModel();
    }
