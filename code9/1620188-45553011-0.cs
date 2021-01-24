        public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        {
            public ApplicationDbContext()
                : base("name=EXISTING_DBContext", throwIfV1Schema: false)
            {
            }
    
            public static ApplicationDbContext Create()
            {
                return new ApplicationDbContext();
            }
        }
