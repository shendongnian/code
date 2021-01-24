    public class MyServiceOrController
    {
    	#region Fields
    
        private readonly IMyEntityRepository _myEntityRepository;
    
    	#endregion
    	
    	#region Constructors
    
    	public MyServiceOrController(IMyEntityRepository myEntityRepository)
    	{
    		_myEntityRepository = myEntityRepository;
    	}
    
    	#endregion
    
    	#region Methods
    	
    	public IList<MyEntity> TestGetAll()
    	{
    		return _myEntityRepository.GetAll();
    	}
    
    	#endregion
    }
