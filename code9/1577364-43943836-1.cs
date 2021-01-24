    public class UnityChildScopedTaskScheduler : ITaskScheduler, IDisposable
    {
    	private IUnityContainer childContainer;
    	
    	private ITaskScheduler realTaskScheduler;
    	private ITaskScheduler taskScheduler
    	{
    		get 
    		{
    			if(realTaskScheduler == null)
    			{
    				realTaskScheduler = childContainer.Resolve<TaskScheduler>();
    			}
    			
    			return realTaskScheduler;
    		}
    	}
    	
    	public UnityChildScopedTaskScheduler(IUnityContainer container) 
    	{
    		childContainer = container.CreateChildContainer();
    	}
        // Implement ITaskScheduler methods, passing the calls to taskScheduler
    	public void Dispose() 
    	{
    		childContainer.Dispose();
    	}
    }
