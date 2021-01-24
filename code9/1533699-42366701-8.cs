    public class MyAwesomeContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Personal> Personals { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // don't forget this...
            modelBuilder.Configurations.Add(new Configuration());
        }
    }
