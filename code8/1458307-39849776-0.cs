    public static T GetPage<T>(Type pageInterface) where T : Helpers
    {
    	// maybe you need to scan different assemblies, depending on your usecase
    	var allTypes = Assembly.GetExecutingAssembly().GetTypes();
    
    	foreach (var pageType in allTypes)
    	{
    		if (pageInterface.IsAssignableFrom(pageType) && pageType.Name.Contains(String.Format(".%1$s.", GetTargetPlatform())))
    		{
    			return (T)Activator.CreateInstance(pageType);
    		}
    	}
    	return (T)Activator.CreateInstance(pageInterface);
    }
