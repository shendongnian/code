	public static void Register(HttpConfiguration config)
	{
		// Json settings
		config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
		config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver { NamingStrategy = new CamelCaseNamingStrategy { ProcessDictionaryKeys = false } };
		config.Formatters.JsonFormatter.SerializerSettings.Formatting = Formatting.Indented;
		JsonConvert.DefaultSettings = () => new JsonSerializerSettings()
		{
			ContractResolver = new CamelCasePropertyNamesContractResolver { NamingStrategy = new CamelCaseNamingStrategy { ProcessDictionaryKeys = false } },
			Formatting = Formatting.Indented,
			NullValueHandling = NullValueHandling.Ignore,
		};
    
    //...
    }
