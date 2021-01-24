        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();
            ApplicationUser user;
            if (DomainUser && IsValidCredentials(context.UserName, context.Password, "MyDomain"))
                user=await PrepareDomainUser(context);
            else 
                user = await userManager.FindAsync(context.UserName, context.Password);
