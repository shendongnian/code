    public class ALongRunningTask : IRunForALongTime
    {
    	private readonly IServiceLocator _serviceLocator;
    
    	public ALongRunningTask(IServiceLocator serviceLocator)
    	{
    		_serviceLocator = serviceLocator;
    	}
    
    	public void Run()
    	{
    		using (_serviceLocator)
    		{
    			var repository = _serviceLocator.Get<IRepository>();
    		}
    	}
    }
