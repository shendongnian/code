    services.AddAuthentication()
        .AddScheme<AuthenticationSchemeOptions, TokenCodeAuthHandler>(
            TokenCodeAuthHandler.DefaultSchemeName, 
            (o) => { });
    //Set Authentication scheme based on policy
    services.AddAuthorization(o =>
    {
        o.AddPolicy("TokenCode", policy =>
        {
            policy.AuthenticationSchemes.Add(TokenCodeAuthHandler.DefaultSchemeName);
            policy.RequireAuthenticatedUser();
        });
    });
