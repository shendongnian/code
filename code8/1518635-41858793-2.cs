        public class Repository : IDisposable
        {
    	    private _dbFactory;
    
        	public Repository(DbFactory dbFactory)
        	{
    	    	_dbFactory = dbFactory;
    	    }
    
        	public void Dispose()
        	{
    	    	_dbFactory.Dispose();
        	}
        } 
