    public class Tenant : ApplicationUser
    {
        // Tenant-specific properties
    }
    public class Owner : ApplicationUser
    {
        // Owner-specific properties
    }
    public class ApplicationUser: IdentityUser
    {
        // Shared properties
    }
