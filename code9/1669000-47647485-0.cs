    public static class ConfigurationRootExtensions
    {
    	private static readonly Regex ArrayKeyRegex = new Regex("^(.+):\\d+$", RegexOptions.Compiled);
    
    	public static IConfigurationRoot FixOverridenArrays(this IConfigurationRoot configurationRoot)
    	{
    		HashSet<string> knownArrayKeys = new HashSet<string>();
    
    		foreach (IConfigurationProvider provider in configurationRoot.Providers.Reverse())
    		{
    			HashSet<string> currProviderArrayKeys = new HashSet<string>();
    
    			foreach (var key in GetProviderKeys(provider, null).Reverse())
    			{
    				//	Is this an array value?
    				var match = ArrayKeyRegex.Match(key);
    				if (match.Success)
    				{
    					var arrayKey = match.Groups[1].Value;
    					//	Some provider overrides this array.
    					//	Suppressing the value.
    					if (knownArrayKeys.Contains(arrayKey))
    					{
    						provider.Set(key, null);
    					}
    					else
    					{
    						currProviderArrayKeys.Add(arrayKey);
    					}
    				}
    			}
    
    			foreach (var key in currProviderArrayKeys)
    			{
    				knownArrayKeys.Add(key);
    			}
    		}
    
    		return configurationRoot;
    	}
    
    	private static IEnumerable<string> GetProviderKeys(IConfigurationProvider provider,
    		string parentPath)
    	{
    		var prefix = parentPath == null
    				? string.Empty
    				: parentPath + ConfigurationPath.KeyDelimiter;
    
    		List<string> keys = new List<string>();
    		var childKeys = provider.GetChildKeys(Enumerable.Empty<string>(), parentPath)
    			.Distinct()
    			.Select(k => prefix + k).ToList();
    		keys.AddRange(childKeys);
    		foreach (var key in childKeys)
    		{
    			keys.AddRange(GetProviderKeys(provider, key));
    		}
    
    		return keys;
    	}
    }
