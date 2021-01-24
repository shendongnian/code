    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAuthentication(o =>
        {
            o.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            o.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
        })
        .AddSingleton<IOptionsMonitor<CookieAuthenticationOptions>, CookieAuthenticationConfigurator>()
        .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme);
    }
