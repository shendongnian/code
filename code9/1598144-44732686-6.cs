    public void ConfigureServices(IServiceCollection services)
    {
        // Add framework services.
        services.AddMvc();
        services.Configure<RouteOptions>(options =>
             options.ConstraintMap.Add("nameId", typeof(NameIdRouteConstraint )));
    }
