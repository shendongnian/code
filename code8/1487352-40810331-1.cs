    public void ConfigureServices(IServiceCollection services)
    {
        // Add framework services.
        services.AddMvc();
        // NOTE: Make this registration AFTER the call to AddMvc
        services.AddSingleton<ITagHelperActivator>(provider =>
            new MultipleTagHelperActivator(
                container,
                new DefaultTagHelperActivator(provider.GetService<ITypeActivatorCache>()),
                useSimpleInjector: type => type.Namespace.StartsWith("MyApplication")));
        // rest of your configuration
    }
