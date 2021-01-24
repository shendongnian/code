    public static Dictionary<string, List<double>> Dataset
    {
           get
    	   {
    		    var ret = new Dictionary<string, List<double>>();
                // Iterate through each key of AppSettings
    		    foreach (string key in ConfigurationManager.AppSettings.AllKeys)
    			    ret.Add(key, Foo(ConfigurationManager.AppSettings[key]));
    		    eturn ret;
    		}
    }
