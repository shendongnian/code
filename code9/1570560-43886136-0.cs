    public class CustomerModelDataContext : DbContext
    {
    	public DbSet<Customer> Customers { get; set; }
    	
    	public DbSet<PostalCode> PostalCodes { get; set; }
    
    	public CustomerModelDataContext()
    		: base("ConnectionName")
    	{
    		Configuration.LazyLoadingEnabled = true;
    		Configuration.ProxyCreationEnabled = true;
    		Database.SetInitializer<CustomerModelDataContext>(new Initializer<CustomerModelDataContext>());
    		//Database.Log = message => DBLog.WriteLine(message);
    	}
    
    	protected override void OnModelCreating(DbModelBuilder modelBuilder)
    	{
    		base.OnModelCreating(modelBuilder);
    	}
    }
