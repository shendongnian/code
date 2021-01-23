    private static string GetDefaultConnectionString()
	{
		var connectionString = ... // Read value from registry
		if (String.IsNullOrEmpty(connectionString))
			connectionString = global::DDSTime.Properties.Settings.Default.DDSTimeConnectionString ;
		return connectionString;
	}
		 
	public DataClassesDataContext() :
				base(GetDefaultConnectionString(), mappingSource)
	{
		OnCreated();
	}
