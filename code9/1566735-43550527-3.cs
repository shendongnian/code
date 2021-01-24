    public class YourDbContext : DbContext
    {
          //Your DbSet
    
         protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        
               //Your modelBuilder
    
            modelBuilder.Conventions.Add(new DateConvention());
        }
    }
