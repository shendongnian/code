     using System;
     using System.Data.Common;
     public static class ConnectionFactory
        {
            /// <summary>
            /// Create DBConnection type based on provider name and connection string
            /// </summary>
            /// <param name="connectionIdentifier"></param>
            /// <returns></returns>
            public static DbConnection CreateDbConnection(string connectionIdentifier)
            {
                // Provider name setting
                var providerNameValue = ConfigurationManager.ConnectionStrings[connectionIdentifier].ProviderName;
    
                // Connection string setting
                var connectionStringValue = ConfigurationManager.ConnectionStrings[connectionIdentifier].ConnectionString;
    
                // Assume failure.
                DbConnection connection;
    
                // Null connection string cannot be accepted
                if (connectionStringValue == null) return null;
    
                // Create the DbProviderFactory and DbConnection.
                try
                {
                    // Fetch provider factory
                    var factory = DbProviderFactories.GetFactory(providerNameValue);
    
                    // Create Connection
                    connection = factory.CreateConnection();
    
                    // Assign connection string
                    if (connection != null)
                        connection.ConnectionString = connectionStringValue;
                }
                catch (Exception ex)
                {
                    connection = null;
                }
                // Return the connection.
                return connection;
            }
    }
