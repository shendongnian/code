    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            if((this.Logins as System.Collections.Generic.List<IdentityUserLogin>).Count>0)
                userIdentity.AddClaim(new Claim("idp", (this.Logins as System.Collections.Generic.List<IdentityUserLogin>)[0].LoginProvider));
            return userIdentity;
        }
    }
