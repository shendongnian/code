    public class AsyncLocker<T>
    {
    	private ConcurrentDictionary<T, Lazy<SemaphoreSlim>> semaphoreDictionary = 
           new ConcurrentDictionary<T, Lazy<SemaphoreSlim>>();
    	public async Task<IDisposable> LockAsync(T key)
    	{
    		var semaphoreLazy = dic.GetOrAdd(key,
                  k => new Lazy<SemaphoreSlim>(() => new SemaphoreSlim(1, 1)));
    		var semaphore = semaphoreLazy.Value;
    		await semaphore.WaitAsync();
    		return new ActionDisposable(() => semaphore.Release());
    	}
    	private class ActionDisposable:IDisposable
    	{
    		private Action action;
    		public ActionDisposable(Action action)
    		{
    			this.action = action;
    		}
    		public void Dispose()
    		{
    			var action = this.action;
    			if(action != null)
    			{
    				action();
    			}
    		}
    	}
    }
