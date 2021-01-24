    public class ConcreteDataAccessService : IDataAccessService
    {
    	public List<int> GetSomeNumbersFromTheDatabase()
    	{
    		// Call db.
    		// Get some numbers.
    		// Return a list of them.
    	}
    }
    
    public IDataAccessService
    {
    	List<int> GetSomeNumbersFromTheDatabase();
    }
   
