    services.AddMvc(options =>
                {
                
    var defaultPolicy = new AuthorizationPolicyBuilder()
        .AddAuthenticationSchemes(IdentityServerAuthenticationDefaults.AuthenticationScheme, BasicAuthenticationDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .Build();
                    options.Filters.Add(new AuthorizeFilter(defaultPolicy));
                });
    services.AddAuthentication()
        .AddIdentityServerAuthentication(option config here)
        .AddBasicAuthentication(setting);
