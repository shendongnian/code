    app.AddAuthentication(o => {
       o.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
       o.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
       o.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    });
