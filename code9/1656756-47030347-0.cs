    using Microsoft.AspNetCore.Mvc.Authorization;
    using Microsoft.AspNetCore.Authorization;
    {...}
    services.AddMvc(config =>
    {
       var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
       config.Filters.Add(new AuthorizeFilter(policy));
    });
