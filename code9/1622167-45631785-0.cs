        public class ApplicationDbContext : IdentityDbContext
        {
            public ApplicationDbContext()
                : base("DefaultConnection")
            {
            }
    
            public static ApplicationDbContext Create()
            {
                return new ApplicationDbContext();
            }
    
            // Add additional DBsets here as needed
        }
