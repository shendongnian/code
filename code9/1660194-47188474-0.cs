    internal class CacheKey
    {
    	public string Role { get; set; }
    
    	public string Controller { get; set; }
    
    	public string Method { get; set; }
    
    	public override bool Equals(Object obj)
    	{
    		CacheKey cmp = obj as CacheKey;
    		if (cmp == null)
    		{
    			return false;
    		}
    
    		return Role == cmp.Role && Controller == cmp.Controller && Method == cmp.Method;
    	}
    
    	public override int GetHashCode()
    	{
    		// Overflow is fine, just wrap
    		unchecked
    		{
    			int hash = 17;
    			hash = hash * 23 + Role.GetHashCode();
    			hash = hash * 23 + Controller.GetHashCode();
    			hash = hash * 23 + Method.GetHashCode();
    			return hash;
    		}
    	}
    }
    public class AuthorizeExtended : AuthorizeAttribute
    {
    	private static ConcurrentDictionary<CacheKey, bool> cache = new ConcurrentDictionary<CacheKey, bool>();
    
    	protected override bool AuthorizeCore(HttpContextBase httpContext)
    	{
    		var isAuthorized = base.AuthorizeCore(httpContext);
    		if (!isAuthorized)
    		{
    			return false;
    		}
    		// Point of interest **HERE**
    
    		//	Looking up in the cache
    		var cacheKey = new CacheKey
    		{
    			Role = role,
    			Controller = controller,
    			Method = method,
    		};
    
    		bool authorized;
    		if (cache.TryGetValue(cacheKey, out authorized))
    		{
    			return authorized;
    		}
    
    		//	Make DB call and get value for authorized
    		//  ...
    		
    		//	Store 'authorized' value in the cache
    		cache.TryAdd(cacheKey, authorized);
    
    		return authorized;
    	}
    }
