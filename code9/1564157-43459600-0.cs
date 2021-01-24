    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", false)
        {
        }
        // Other code omitted for brevity
    }
