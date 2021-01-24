    public static class BundleHelpers
    {
    	public static BundleCollection JoinScriptBundle(this BundleCollection bundleCollection, string virtualPath, params string[] bundlesToJoin)
    	{
    		var bundleResolver = new BundleResolver(bundleCollection);
    		Bundle allScriptBundle = new ScriptBundle(virtualPath);
    		foreach (var bundle in bundlesToJoin)
    		{
    			foreach (var scriptPath in bundleResolver.GetBundleContents(bundle))
    			{
    				allScriptBundle = allScriptBundle.Include(scriptPath);
    			}
    		}
    		bundleCollection.Add(allScriptBundle);
    		return bundleCollection;
    	}
    }
    
