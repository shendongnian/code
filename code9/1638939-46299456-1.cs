    services.AddMvc(
        _ =>
        {
            _.Filters.Add(
               new AuthorizeFilter(
                   new AuthorizationPolicyBuilder(
                     JwtBearerDefaults.AuthenticationScheme,
                     IdentityConstants.ApplicationScheme)
                   .RequireAuthenticatedUser()
                     .Build()));
            _.Filters.Add(new ActiveUserFilter());
            ...
