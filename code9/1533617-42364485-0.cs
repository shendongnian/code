    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
            {
                // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
                var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
                var userId = userIdentity.GetUserId();
                var role = manager.GetRoles(userId);
    
                // Add custom user claims here
                userIdentity.AddClaims(new[] {
                    new Claim("Your claim name", Value that you want to store it)
                    });
                return userIdentity;
            }
