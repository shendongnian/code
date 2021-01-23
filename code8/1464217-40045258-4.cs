     private string GetEFConnectionString()
     {
        string providerName = "System.Data.SqlClient";
        string serverName = @".\SQL2008";
        string databaseName = "my-db";
        // Initialize the connection string builder for the
        // underlying provider.
        var sqlBuilder = new SqlConnectionStringBuilder();
        // Set the properties for the data source.
        sqlBuilder.DataSource = serverName;
        sqlBuilder.InitialCatalog = databaseName;
        sqlBuilder.IntegratedSecurity = true;
        // Build the SqlConnection connection string.
        string providerString = sqlBuilder.ToString();
        // Initialize the EntityConnectionStringBuilder.
        var entityBuilder = new EntityConnectionStringBuilder();
        // Set the provider name.
        entityBuilder.Provider = providerName;
        // Set the provider-specific connection string.
        entityBuilder.ProviderConnectionString = providerString;
        // Set the Metadata location.
        entityBuilder.Metadata = @"res://*/Model.csdl|
          res://*/Model.ssdl|
          res://*/Model.msl";
        return entityBuilder.ToString();
    }
