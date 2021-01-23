    services.AddMvc(config =>
    {
        var policy = new AuthorizationPolicyBuilder()
                         .RequireUserName("DOMAIN\\USERID")
                         .Build();
    
        config.Filters.Add(new AuthorizeFilter(policy));
    });
