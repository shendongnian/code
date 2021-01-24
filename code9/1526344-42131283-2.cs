    class ConnectionHelper
        {
            public static string CreateConnectionString(LocationModel LM, string metaData)
            {
                const string appName = "EntityFramework";
                const string providerName = "System.Data.SqlClient";
    
                SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();
                sqlBuilder.DataSource = LM.datasource;
                sqlBuilder.InitialCatalog = LM.catalog;
                sqlBuilder.UserID = LM.Username;
                sqlBuilder.Password = LM.Password;
                sqlBuilder.MultipleActiveResultSets = true;
                sqlBuilder.PersistSecurityInfo = true;
                sqlBuilder.ApplicationName = appName;
            
    EntityConnectionStringBuilder efBuilder = new EntityConnectionStringBuilder();
            efBuilder.Metadata = metaData;
            efBuilder.Provider = providerName;
            efBuilder.ProviderConnectionString = sqlBuilder.ConnectionString;
            var t = efBuilder.ConnectionString;
            return efBuilder.ConnectionString;
        }
        
        public static FastecData CreateConnection(LocationModel locationmodel, string metaData = "res://*/DB.ServerData.csdl|res://*/DB.ServerData.ssdl|res://*/DB.ServerData.msl")
        {
            return new FastecData(ConnectionHelper.CreateConnectionString(locationmodel, metaData));
        }
    }
