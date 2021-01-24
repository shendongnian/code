    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("MainContext", throwIfV1Schema: false)
        {
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        // put your extra entities here like this.
        public IDbSet<MyEntity> MyEntites { get; set;}
        // don't put Identity related entities like AspNetRoles. Since already added
    }  
