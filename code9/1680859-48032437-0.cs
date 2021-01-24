    void CreateNewConnectionString(string baseName, string newName, string newDatabaseName)
    {
        // Get the connection string a new connection will be based on
    	string baseConnString =
            ConfigurationManager.ConnectionStrings[baseName].ConnectionString;
        // For simplicity of manipulations with connection strings,
        // we use SqlConnectionStringBuilder, passing it an existing connection string
    	var connBuilder = new SqlConnectionStringBuilder(baseConnString);
        // Change existing database name to the new database name
    	connBuilder.InitialCatalog = newDatabaseName;
        // Create new settings, holding our new connection string
    	var newConnection = new ConnectionStringSettings(newName, connBuilder.ToString());
        // Save new connection string
    	var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
    	config.ConnectionStrings.ConnectionStrings.Add(newConnection);
    	config.Save(ConfigurationSaveMode.Modified);
    }
