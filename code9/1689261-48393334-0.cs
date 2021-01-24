    private string TryOperation(Action operation)
    {
    	using (var guard = new OperationGuardWithCleanup())
    	{
    		if (guard.TryStartOperation())
    		{
    			operation();
    			return "Success";
    		}
    		else
    		{
    			return "false";
    		}
    	}
    }
    
    public class OperationGuardWithCleanup : IDisposable
    {
    	private bool disposedValue = false;
    	private static readonly object _operationLock = new object();
    
    	public OperationGuardWithCleanup()
    	{
    		Monitor.Enter(_operationLock);
    	}
    
    	public bool TryStartOperation()
    	{
    		// ?
    		return true;
    	}
    
    	protected virtual void Dispose(bool disposing)
    	{
    		if (!disposedValue)
    		{
    			if (disposing)
    			{
    				Monitor.Exit(_operationLock);
    			}
    
    			disposedValue = true;
    		}
    	}
    
    	public void Dispose()
    	{
    		Dispose(true);
    	}
    }
