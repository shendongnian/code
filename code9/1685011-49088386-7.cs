    public static class AssetDatabaseUtility
    	{
    
    		public static string AbsoluteUrlToAssets(string absoluteUrl)
    		{
    			Uri fullPath = new Uri (absoluteUrl, UriKind.Absolute);
    			Uri relRoot = new Uri (Application.dataPath, UriKind.Absolute);
    			
    			return relRoot.MakeRelativeUri (fullPath).ToString ();
    			
    			
    		}
    	}
