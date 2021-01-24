    public class MyAwesomeContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ApplicationUser> Users { get; set; } // this shouldn't exist 
        public DbSet<Personal> Personals { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new Configuration());
        }
    }
