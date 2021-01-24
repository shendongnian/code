    public static void Register(HttpConfiguration config)
    {
    	//default Code...
    
    	var json = config.Formatters.JsonFormatter;
    	json.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize;
    }
