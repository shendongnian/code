    /// <summary>
    /// Returns a list of configured handler names
    /// </summary>
    /// <param name="filter">the handler name must contain this value to be included in the list</param>
    /// <returns>a list of handler names that matches the filter or all handler names if filter is null</returns>
    public static List<string> GetHandlerNames(string filter)
    {
    	string websiteName = System.Web.Hosting.HostingEnvironment.ApplicationHost.GetSiteName();
    	Configuration o = srvMgr.GetWebConfiguration(websiteName);
    	ConfigurationElementCollection c1 = o.GetSection("system.webServer/handlers").GetCollection();
    
    	if (filter != null)
    	{
    		return c1.Where(x => x.GetAttribute("name").Value.ToString().ToLowerInvariant().Contains(filter.ToLowerInvariant())).Select(x => x.GetAttributeValue("name").ToString()).ToList();
    	}
    	else
    	{
    		return c1.Select(x => x.GetAttributeValue("name").ToString()).ToList();
    	}
    }	
    /// <summary>
    /// Returns a list of configured handler paths 
    /// </summary>
    /// <param name="filter">the handler name must contain this value to be included in the list</param>
    /// <returns>a list of handler paths that matches the filter or all handler paths if filter is null</returns>
    public static List<string> GetHandlerPaths(string filter)
    {
    	string websiteName = System.Web.Hosting.HostingEnvironment.ApplicationHost.GetSiteName();
    	Configuration o = srvMgr.GetWebConfiguration(websiteName);
    	ConfigurationElementCollection c1 = o.GetSection("system.webServer/handlers").GetCollection();
    
    	if (filter != null)
    	{
    		return c1.Where(x => x.GetAttribute("name").Value.ToString().ToLowerInvariant().Contains(filter.ToLowerInvariant())).Select(x => x.GetAttributeValue("path").ToString().Replace("*.", "")).ToList();
    	}
    	else
    	{
    		return c1.Select(x => x.GetAttributeValue("path").ToString()).ToList();
    	}
    }
