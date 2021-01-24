     public class YourDbContext : DbContext
{
           protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    
        modelBuilder.Conventions.Add(new DateConvention());
    }
