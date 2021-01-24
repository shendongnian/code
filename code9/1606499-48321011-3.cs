    public static IServiceProvider Build(IServiceCollection services)
    {
        //.....
        services.AddSingleton<IHostedService, UpdateBackgroundService>();
        services.AddTransient<IHostedService, UpdateBackgroundService>();  //For run at startup and die.
        //.....
    }
