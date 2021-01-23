    public class BL<TModel>
    {
    	// This is what i want to make dynamic.
    	// how do i create a return type that i can use in DA<>..
    	private Type testDetermineDatabaseModel()
    	{
    		switch(typeof(TModel).Name){
    			case "Categories":
    				return typeof(Database.Categories);
    			case "Users":
    				return typeof(Database.Users);
    		}
    		
    		return null;
    	}
    	
    	public ICollection<TModel> testGetAll() 
    	{
    		var databaseModel = testDetermineDatabaseModel();
    		// return DA<databaseModel>().Base.GetAll();
    		return new List<TModel>();
    	}
    	
    	// NEW
    	// I have constructed the following.
    	private dynamic  baseService;
    	
    	public dynamic DetermineDatabaseModel()
    	{
    		switch (typeof(TModel).Name)
    		{
    			case "Categories":
    				return new BaseService<Database.Categories>();
    			case "Users":
    				return new BaseService<Database.Users>();
    			default:
    				return null;
    		}
    	}
    	
    	private IBaseService<TDbModel> GetBase<TDbModel>() where TDbModel : class
    	{
    		return new BaseService<TDbModel>();
    	}
    	
    	public ICollection<TModel> GetAll()
    	{
    		
    		ICollection<TModel> returnValue = new List<TModel>();
    		// This works!!!
    		foreach (var item in GetBase<Database.Categories>().GetAll())
    		{
    			returnValue.Add((TModel)(object)item);
    		}
    		
    		baseService = DetermineDatabaseModel();
    		// This doesn't!!! It's the same thing!! :(
    		foreach (var item in baseService.GetAll())
    		{
    			returnValue.Add((TModel)(object)item);
    		}
    		
    		return returnValue;
    	}
    }
