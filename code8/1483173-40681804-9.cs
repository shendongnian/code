    public class EfDataRepository : DbContext, IDataRepository
    {
    	public EfDataRepository() : base("dataRepositoryConnection")
    	{
    	}
    
    	public IDbSet<Order> Orders { get; set; }
    
    	public void Save()
    	{
    		this.SaveChanges();
    	}
    }
    
