    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("name=MainContext")
        {
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
