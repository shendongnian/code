    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
      public Configuration()
      {
        AutomaticMigrationsEnabled = true;
      }
      protected override void Seed(ApplicationDbContext context)
      { 
      }
    }
