    public interface IDataRepository : IDisposable
    {
    	IDbSet<Order> Orders { get; set; }
    	
    	void Save();
    }
    
