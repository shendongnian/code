    app.UseCookieAuthentication(new CookieAuthenticationOptions
        {
            AuthenticationScheme = AuthenticationSchemeConstants.DefaultCookieAuthenticationScheme,
            CookieName = $"{AuthenticationSchemeConstants.CookiePrefixName}.auth",
            ExpireTimeSpan = TimeSpan.FromMinutes(20),
            SlidingExpiration = true,
            AutomaticAuthenticate = false,
            AutomaticChallenge = false
        });
    
        app.UseCookieAuthentication(new CookieAuthenticationOptions
        {
            AuthenticationScheme = AuthenticationSchemeConstants.ExternalCookieAuthenticationScheme,
            AutomaticAuthenticate = false,
            AutomaticChallenge = false
        });
    
        app.UseIdentityServer();
