       services.Configure<IdentityOptions>(options =>
    {
        options.ClaimsIdentity.UserNameClaimType = OpenIdConnectConstants.Claims.Name;
        options.ClaimsIdentity.UserIdClaimType = OpenIdConnectConstants.Claims.Subject;
        options.ClaimsIdentity.RoleClaimType = OpenIdConnectConstants.Claims.Role;
    });
