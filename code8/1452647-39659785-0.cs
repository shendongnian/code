        [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
        public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        {
            public ApplicationDbContext()
                : base("CaptureDBContext", throwIfV1Schema: false)
            {
            }
    
            public static ApplicationDbContext Create()
            {
                return new ApplicationDbContext();
            }
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                modelBuilder.Entity<ApplicationUser>().Property(u => u.UserName).HasMaxLength(255);
                modelBuilder.Entity<ApplicationUser>().Property(u => u.Email).HasMaxLength(255);
                modelBuilder.Entity<IdentityRole>().Property(r => r.Name).HasMaxLength(255);
            }
        }
    }
