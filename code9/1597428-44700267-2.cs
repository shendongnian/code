	JsonConvert.DefaultSettings = () =>
	{
		return new JsonSerializerSettings
		{
			ContractResolver = new PropertyNameMapContractResolver(new Dictionary<string, string>()
			{
				{ "ID", "id" }
			})
		};
	};
