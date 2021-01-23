    public class MemoryCacheStore : ITicketStore
    {
    	private const string KeyPrefix = "AuthSessionStore-;
    	private readonly IMemoryCache _cache;
    
    	public MemoryCacheStore(IMemoryCache cache)
    	{
    		_cache = cache;
    	}
    
    	public async Task<string> StoreAsync(AuthenticationTicket ticket)
    	{
    		var key = KeyPrefix + Guid.NewGuid();
    		await RenewAsync(key, ticket);
    		return key;
    	}
    
    	public Task RenewAsync(string key, AuthenticationTicket ticket)
    	{
            // https://github.com/aspnet/Caching/issues/221
            // Set to "NeverRemove" to prevent undesired evictions from gen2 GC
    		var options = new MemoryCacheEntryOptions
            {
                Priority = CacheItemPriority.NeverRemove
            };
    		var expiresUtc = ticket.Properties.ExpiresUtc;
    		
    		if (expiresUtc.HasValue)
    		{
    			options.SetAbsoluteExpiration(expiresUtc.Value);
    		}    
    		
    		options.SetSlidingExpiration(TimeSpan.FromMinutes(60));
    
    		_cache.Set(key, ticket, options);
    
    		return Task.FromResult(0);
    	}
    
    	public Task<AuthenticationTicket> RetrieveAsync(string key)
    	{
    		AuthenticationTicket ticket;
    		_cache.TryGetValue(key, out ticket);
    		return Task.FromResult(ticket);
    	}
    
    	public Task RemoveAsync(string key)
    	{
    		_cache.Remove(key);
    		return Task.FromResult(0);
    	}
    }
