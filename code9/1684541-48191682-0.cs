    public SignInManager(
        UserManager<TUser> userManager,
        IHttpContextAccessor contextAccessor,
        IUserClaimsPrincipalFactory<TUser> claimsFactory,
        IOptions<Microsoft.AspNetCore.Identity.IdentityOptions> optionsAccessor,
        ILogger<Microsoft.AspNetCore.Identity.SignInManager<TUser>> logger,
        IAuthenticationSchemeProvider schemes);
