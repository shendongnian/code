    public class ApplicationUser : IdentityUser
    {
        ppublic async Task<ClaimsIdentity> AssignUserIdentityAsync(UserManager<ApplicationUser> manager)
        {        
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);     
            userIdentity.AddClaim(new Claim("FirstName", this.FirstName.ToString()));
    
            return userIdentity;
        }
    
        // Custom filed
        public long? FirstName { get; set; }
        //and so on
    }
    
    namespace Extensions
    {
        public static class IdentityExtensions
        {
            public static string GetFirstName(this IIdentity identity)
            {
                var claim = ((ClaimsIdentity)identity).FindFirst("FirstName");            
                return claim ?? string.Empty;
            }
    
            // and so on
        }
    }
