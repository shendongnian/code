    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string,
            IdentityUserLogin, IdentityUserRole, ApplicationUserClaim>
    {
    	// ...
    }
    public class ApplicationUser : IdentityUser<string, IdentityUserLogin, IdentityUserRole, ApplicationUserClaim>
    {
    	// ...
    }
