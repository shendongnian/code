    public class ConsoleDbContext : DbContext
    {
      public ConsoleDbContext ()
        : base("name=ConsoleDbContext")
      { }
      public DbSet<Entity> ConsoleEntities { get; set; } 
    }
