    // Before
    services.AddAbpIdentity<Tenant, User, Role>()
    // After
    services.AddAbpIdentity<Tenant, User, Role>(options =>
    {
        options.Cookies.ApplicationCookie.AutomaticChallenge = false;
    })
