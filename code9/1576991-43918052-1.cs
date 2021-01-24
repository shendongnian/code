    class Cache<TKey, TValue>
    {
    	private ConcurrentDictionary<TKey, Item> d = new ConcurrentDictionary<TKey, Item>();
    
    	private class Item
    	{
    		public Item(Func<Task<TValue>> loadingTask, TimeSpan ttl, CancellationToken cancellationToken)
    		{
    			Ttl = ttl;
    			LoadingTask = loadingTask;
    			ServiceTask = HandleLoaded();
    			CancellationToken = cancellationToken;
    		}
    
    		CancellationToken CancellationToken { get; }
    		Func<Task<TValue>> LoadingTask { get; set; }
    		public Task<TValue> ServiceTask {get; private set;}
    		private TimeSpan Ttl { get; }
    		
    		async Task<TValue> HandleLoaded()
    		{
    			var value = await LoadingTask();
    			ServiceTask = Task.FromResult(value);			
    			Task.Run(() => ReloadOnExpiration(), CancellationToken);
    			return value;
    		}
    		
    		async void ReloadOnExpiration()
    		{
    			if (CancellationToken.IsCancellationRequested)
    				return;
    			await Task.Delay(Ttl, CancellationToken);
    			var value = await LoadingTask();
    			ServiceTask = Task.FromResult(value);
    			ReloadOnExpiration();
    		}
    	}
    
    	public async Task<TValue> GetOrCreate(TKey key, Func<TKey, CancellationToken, Task<TValue>> createNew, CancellationToken cancallationToken, TimeSpan ttl)
    	{
    		var item = d.GetOrAdd(key, k => new Item(() => createNew(key, cancallationToken), ttl, cancallationToken));
    		return await item.ServiceTask;
    	}
    }
