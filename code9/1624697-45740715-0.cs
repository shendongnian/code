    public IServiceProvider ConfigureServices(IServiceCollection services) {
        services.AddMvc()
                .AddControllersAsServices();
    
        var container = new Container(rules => rules.With(propertiesAndFields: PropertiesAndFields.Auto))
                       .WithDependencyInjectionAdapter(services);
        var provider = container.ConfigureServiceProvider<CompositionRoot>();
        return provider
    }
