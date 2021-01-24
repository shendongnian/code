    public class Context : DbContext
    {    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        { 
             // Unfortunately you have to specify each table you want to set a schema for...
             modelBuilder.Entity<Woningen>().ToTable("Woningen", "YourSchemaName");
        } 
    }
