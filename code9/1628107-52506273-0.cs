    services
        .AddAuthentication("MyAuthScheme")
        .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
        {
            options.EventsType = typeof(MyEventsWrapper);
        };
    ...
    services.AddTransient<MyEventsWrapper>();
    services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
