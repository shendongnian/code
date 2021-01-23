    public partial class FulfillmentEntities : DbContext, IUnitOfWork
    {
    	public FulfillmentEntities()
    		: base("name=FulfillmentEntities")
    	{
    	}
    
    	protected override void OnModelCreating(DbModelBuilder modelBuilder)
    	{
    		throw new UnintentionalCodeFirstException();
    	}
    
    	public IDbSet<Log> Logs { get; set; }
    
    	public IDbSet<Order> Orders { get; set; }
    
    
    	public void Commit()
    	{
    		SaveChanges();
    	}
    
    }
