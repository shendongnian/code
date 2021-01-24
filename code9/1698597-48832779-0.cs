    services.AddAuthentication(o =>
    {
        o.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        o.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        o.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    })
