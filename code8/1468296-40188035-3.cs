    services.AddMvc(config =>
    {
        var policyBuilder = new AuthorizationPolicyBuilder();
        policyBuilder.Requirements.Add(new UserNamesRequirement("DOMAIN\\USER1"));
        // this will NOT work
        policyBuilder.Build();
        config.Filters.Add(new AuthorizeFilter(policyBuilder));
        // this will work
        var policy = policyBuilder.Build();
        config.Filters.Add(new AuthorizeFilter(policy));
    });
