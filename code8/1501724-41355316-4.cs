    public void ConfigureServices(IServiceCollection services)
    {
        // Register the OpenIddict services.
        services.AddOpenIddict(options =>
        {
            // Register the Entity Framework stores.
            options.AddEntityFrameworkCoreStores<ApplicationDbContext>();
        
            // Register the ASP.NET Core MVC binder used by OpenIddict.
            // Note: if you don't call this method, you won't be able to
            // bind OpenIdConnectRequest or OpenIdConnectResponse parameters.
            options.AddMvcBinders();
        
            // Enable the authorization endpoint.
            options.EnableAuthorizationEndpoint("/connect/authorize");
        
            // Enable the implicit flow.
            options.AllowImplicitFlow();
        
            // During development, you can disable the HTTPS requirement.
            options.DisableHttpsRequirement();
        
            // Register a new ephemeral key, that is discarded when the application
            // shuts down. Tokens signed using this key are automatically invalidated.
            // This method should only be used during development.
            options.AddEphemeralSigningKey();
        });
    
        // Note: when using WebListener instead of IIS/Kestrel, the following lines must be uncommented:
        //
        // services.Configure<WebListenerOptions>(options =>
        // {
        //     options.ListenerSettings.Authentication.AllowAnonymous = true;
        //     options.ListenerSettings.Authentication.Schemes = AuthenticationSchemes.Negotiate;
        // });
    }
