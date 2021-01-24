    public class MyContext : DbContext
    {
        // Do not include a DbSet for Person.
        public DbSet<Sales> Sales { get; set; }
        public DbSet<CustomerService> CustomerService { get; set; }
     
        // ...
    }
