    // Specify the provider name, server and database.
            string providerName = "System.Data.SqlClient";
            string serverName = ".";
            string databaseName = "AdventureWorks";
            // Initialize the connection string builder for the
            // underlying provider.
            SqlConnectionStringBuilder sqlBuilder =
                new SqlConnectionStringBuilder();
            // Set the properties for the data source.
            sqlBuilder.DataSource = serverName;
            sqlBuilder.InitialCatalog = databaseName;
            sqlBuilder.IntegratedSecurity = true;
            // Build the SqlConnection connection string.
            string providerString = sqlBuilder.ToString();
            // Initialize the EntityConnectionStringBuilder.
            EntityConnectionStringBuilder entityBuilder =
                new EntityConnectionStringBuilder();
            //Set the provider name.
            entityBuilder.Provider = providerName;
            // Set the provider-specific connection string.
            entityBuilder.ProviderConnectionString = providerString;
            // Set the Metadata location.
            entityBuilder.Metadata = @"res://*/AdventureWorksModel.csdl|
                            res://*/AdventureWorksModel.ssdl|
                            res://*/AdventureWorksModel.msl";
            Console.WriteLine(entityBuilder.ToString());
            using (EntityConnection conn =
                new EntityConnection(entityBuilder.ToString()))
            {
                conn.Open();
                Console.WriteLine("Just testing the connection.");
                conn.Close();
            }
