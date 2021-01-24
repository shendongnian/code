        private async Task<ApplicationUser> PrepareDomainUser(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();
            ApplicationUser user = await userManager.FindByEmailAsync(context.UserName);
            if (user == null)
            {
                user = new ApplicationUser() { UserName = context.UserName, Email = context.UserName };
                IdentityResult result = await userManager.CreateAsync(user);
            }
            return user;
        }
