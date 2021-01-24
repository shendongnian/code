    var settings = new JsonSerializerSettings()
    {
    	ContractResolver = new DefaultContractResolver()
    	{
    		IgnoreSerializableInterface = true,
    	},
    	ReferenceLoopHandling = ReferenceLoopHandling.Ignore
    };
    
    var json = JsonConvert.SerializeObject(new ArgumentNullException("argument", "Some Message"), settings);
