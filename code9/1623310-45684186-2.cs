    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        //: base("DefaultConnection", throwIfV1Schema: false)
            : base("DefaultConnection")
        {
            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 6000;
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
