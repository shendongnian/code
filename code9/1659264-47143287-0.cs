    public class RequestContextHandler : IRequestContextHandler
    {
    	public ICookieManager GetCookieManager()
    	{
    		return null;
    	}
    
    	public bool OnBeforePluginLoad(string mimeType, string url, bool isMainFrame, string topOriginUrl, WebPluginInfo pluginInfo, ref PluginPolicy pluginPolicy)
    	{
    		
    		bool blockPluginLoad = pluginInfo.Name.ToLower().Contains("flash");
    		if (blockPluginLoad)
    		{
    			pluginPolicy = PluginPolicy.Disable;
    		}
    		return blockPluginLoad;
    	}
    } 
