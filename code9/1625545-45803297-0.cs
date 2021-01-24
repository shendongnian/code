    services.AddMvcCore(a =>
    {
        var policy = new AuthorizationPolicyBuilder().AddAuthenticationSchemes(CookieAuthenticationDefaults.AuthenticationScheme).RequireAuthenticatedUser().Build();
        a.Filters.Add(new AuthorizeFilter(policy));
    });
