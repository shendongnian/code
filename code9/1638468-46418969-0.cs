    public abstract class BaseModel 
    {
        //exactly Guid, not int!
        public Guid Id {get;set;}
        public string Name {get;set;}
    }
    
    public class Customer : BaseModel 
    {
        public string CustomerProperty {get;set;}
    }
    
    public class Supplier : BaseModel 
    {
        public string SupplierProperty {get;set;}
    }
    public class Log
    {
        //other properties...
        //public EntityType EntityType { get; set; }    
        public virtual BaseModel Entity { get; set; }
    }
    
    public class MyContext : DbContext
    {
        public DbSet<BaseModel> Entities  { get; set; }
        public DbSet<Log> Logs { get; set; }
            
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Customers");
            });
     
            modelBuilder.Entity<Supplier>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Suppliers");
            });            
        }
    }
