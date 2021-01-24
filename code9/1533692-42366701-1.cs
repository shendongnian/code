    public class MyAwesomeContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Personal> Personals { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new Configuration());
        }
    }
