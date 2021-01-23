    public class MyCountriesContext : IdentityDbContext<ApplicationUser>
    {
      public MyCountriesContext()
      {
        Database.EnsureCreated();
      }
     
      public DbSet<Visit> Visits { get; set; }
     
      protected override void OnModelCreating(ModelBuilder builder)
      {
        builder.Entity<Visit>().Key(v => v.Id);
     
        base.OnModelCreating(builder);
      }
    }
