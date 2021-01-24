    public static IServiceCollection AddAllCoolStuff(this IServiceCollection services)
    {
        if (services == null)
        {
            throw new ArgumentNullException(nameof(services));
        }
        services.AddSingleton<FooService>();
        services.AddTransient<IBooService, BooService>();
        ...
        return services;
    }
    public static IApplicationBuilder UseAllCoolStuff(this IApplicationBuilder app)
    {
        if (app == null)
        {
            throw new ArgumentNullException(nameof(app));
        }
        app.UseMiddleware<SomeCoolMiddleware>();
        ...
        return app;
    }
