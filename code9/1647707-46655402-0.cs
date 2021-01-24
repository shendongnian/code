    public class StoreDB : DbContext
    { 
            public StoreDB() : base() //Add a parameter to Base to specify an existing dB
            {
                Database.SetInitializer<StoreDB>(new DropCreateDatabaseIfModelChanges<StoreDB>());
    
            }
    
            public DbSet<Product> products { get; set; }
            public DbSet<Order> orders { get; set; }
            public DbSet<Order_Line> order_lines { get; set; }
    }
