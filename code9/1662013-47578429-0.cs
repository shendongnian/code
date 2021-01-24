    private Func<CookieValidateIdentityContext, System.Threading.Tasks.Task> _validate=SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
               validateInterval: TimeSpan.FromMinutes(30),
               regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager));
    private async Task validate(CookieValidateIdentityContext context)
    {
        var usermanager = context.OwinContext.GetUserManager<ApplicationUserManager>();
        var claims = await usermanager.GetClaimsAsync(context.Identity.GetUserId());
        
        //instead of setting to true, add your session validation logic here
        bool sessionIsValid=true;
        if (!sessionIsValid) {
            context.RejectIdentity();
            context.OwinContext.Authentication.SignOut(context.Options.AuthenticationType);
        }
        
        await _validate(context);
    }
    
    
