    public IServiceProvider ConfigureServices(IServiceCollection services)
    {
        ...
        var builder = new ContainerBuilder();
        builder.RegisterModule(new HowResolveDependencies());
            
        services.AddTransient<IExceptionHandler, ExceptionToResponseWriter>();
            
        builder.Populate(services);
            
        services.AddAuthentication(AuthConsts.MainAuthScheme)
                     .AddCookie(
        ...
    }
