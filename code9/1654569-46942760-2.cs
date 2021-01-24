    // requires: using Microsoft.AspNetCore.Authorization;
    //           using Microsoft.AspNetCore.Mvc.Authorization;
    services.AddMvc(config =>
    {
        var policy = new AuthorizationPolicyBuilder()
                         .RequireAuthenticatedUser()
                         .Build();
        config.Filters.Add(new AuthorizeFilter(policy));
    });
