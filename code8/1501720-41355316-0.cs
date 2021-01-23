    // Register the OpenIddict services.
    services.AddOpenIddict()
        // Register the Entity Framework stores.
        .AddEntityFrameworkCoreStores<ApplicationDbContext>()
    
        // Register the ASP.NET Core MVC binder used by OpenIddict.
        // Note: if you don't call this method, you won't be able to
        // bind OpenIdConnectRequest or OpenIdConnectResponse parameters.
        .AddMvcBinders()
    
        // Enable the authorization endpoint.
        .EnableAuthorizationEndpoint("/connect/authorize")
    
        // Enable the implicit flow.
        .AllowImplicitFlow()
    
        // During development, you can disable the HTTPS requirement.
        .DisableHttpsRequirement()
    
        // Register a new ephemeral key, that is discarded when the application
        // shuts down. Tokens signed using this key are automatically invalidated.
        // This method should only be used during development.
        .AddEphemeralSigningKey();
