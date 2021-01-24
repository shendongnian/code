    public void ConfigureServices(IServiceCollection services)
    {
        services
        .AddAuthentication()
        .AddOpenIdConnect(options =>
            {
                options.Events.OnRedirectToIdentityProvider = context =>
                 {
                      // Retrieve identity from current HttpContext
                      var identity = context.HttpContext.User.Identity;
    
                      // Lookup for your client_id and client_secret
                      var clientId = "find your client id";
                      var clientSecret = "find your client secret";
    
                      // Assign client_id and client_secret
                      context.Options.ClientId = clientId;
                      context.Options.ClientSecret = clientSecret;
    
                      return Task.FromResult(0);
                  };
             });
    }
