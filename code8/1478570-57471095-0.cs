    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
           CookieAuthenticationOptions.AuthenticationType
           var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
           
           // Add custom user claims here
            userIdentity.AddClaim(new Claim("Code",this.Code));
           return userIdentity;
        }
        //My extended property
        public string Code { get; set; }
    }
