    public class AsyncWrapper
    {	
	  public async Task CallWcfAsync(<Parameters>)
	  {  
           SynchronizationContext _synchronizationContext = 
           SynchronizationContext.Current;
        try
        {
          SynchronizationContext.SetSynchronizationContext(null);
		  await Task.Run(() => CallWcfMethod(<Parameters>));
        }
        finally
        {             
          SynchronizationContext.SetSynchronizationContext
          (_synchronizationContext);
        }	
	  }
    }
