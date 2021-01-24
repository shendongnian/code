    // Session Configuration
    services.AddSession(options =>
    {
        options.IdleTimeout = TimeSpan.FromHours(4);
        options.Cookie.HttpOnly = true; // correct initialization
    });
