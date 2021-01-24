    public static class CrmServiceClientCache
    {
    	private static Dictionary<string, CrmServiceClient> _internalCache = new Dictionary<string, CrmServiceClient>();
    
    	private static Object _objLock = new object();
    
    	public static CrmServiceClient Get(string connectionString)
    	{
    		if (_internalCache.ContainsKey(connectionString)) return _internalCache[connectionString];
    		else
    		{
    			lock (_objLock)
    			{
    				if (!_internalCache.ContainsKey(connectionString) && _internalCache[connectionString] != null)
    				{
    					var svcClient = new CrmServiceClient(connectionString);
    					if (svcClient.IsReady) _internalCache[connectionString] = svcClient;
    					else throw new Exception($"Failed to Successfully Create CrmServiceClient: {svcClient.LastCrmError}", svcClient.LastCrmException);
    				}
    				return _internalCache[connectionString];
    			}
    		}
    	}
    }
