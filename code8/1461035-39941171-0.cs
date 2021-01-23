    public class MyDBContext: DbContext 
    {
            
        public MyDBContext(): base("YourConnectionString") 
        {
            //This is default initializer
            Database.SetInitializer<MyDBContext>(new CreateDatabaseIfNotExists<MyDBContext>());
           
        }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
