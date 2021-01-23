    public static ApplicationInfo AppInfo
    {
	    get
	    {
		    HttpRuntime.Cache["ApplicationInfo"] as ApplicationInfo; //using System.Web;
		    //Or, if you prefer this: 
		    //MemoryCache.Default["ApplicationInfo"] as ApplicationInfo; //using System.Runtime.Caching;
	    }
	    set
	    {
		    HttpRuntime.Cache["ApplicationInfo"] = value; //using System.Web;
		    //Or, if you prefer this: 
		    //MemoryCache.Default["ApplicationInfo"] = value; //using System.Runtime.Caching;
	    }
    }
