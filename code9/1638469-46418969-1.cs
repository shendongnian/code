    public abstract class BaseModel 
    {
        public Guid Id {get;set;}
        public string SomeCommonProperty {get;set;}
    }    
    public class Log
    {
        //other properties...
        //EntityType is not needed, but you can leave it    
        public EntityType EntityType { get; set; }
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
