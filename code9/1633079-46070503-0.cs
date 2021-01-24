    public class Context : DbContext
    {  
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Set a default schema for ALL tables
            modelBuilder.HasDefaultSchema("YourSchemaName");
        }
    }
