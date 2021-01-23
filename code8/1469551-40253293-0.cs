    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {        
        public ApplicationDbContext()
            : base("aspNetIdentity", throwIfV1Schema: false)
        {
        }
        public ApplicationDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }
        public static ApplicationDbContext Create()
        {            
            return new ApplicationDbContext(ConnectionStringProvider.ConnectionString);
        }
    }
