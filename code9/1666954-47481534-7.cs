    public void ConfigureServices(IServiceCollection services)
    {
        // All your other service configuration stuff
        services.AddMvc(options =>
        {
            // add custom binder to beginning of collection
            options.ModelBinderProviders.Insert(0, new ArabicDateTimeBinderProvider());
        });
    }
