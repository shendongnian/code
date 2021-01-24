    public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
    {
        var scope = context.OwinContext.GetAutofacLifetimeScope();
        var userManager = scope.Resolve<ApplicationUserManager>();
        
        .........
    }
