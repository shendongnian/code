            ...
            XAttribute provider = connectionStringElement.Attribute("providerName");
            string providerValue = provider == null ? string.Empty : provider.Value;
            bool isEntityFramework = providerValue.Equals("System.Data.EntityClient");
            dbConn = BuildDataSourceFromString(connectionStringValue, isEntityFramework);
            if (dbConn == null)
            {
                return;
            }
            
            connectionStrings.Add(dbConn);
        }
        private static DataSource BuildDataSourceFromString(string connectionString, bool isEntityFramework)
        {
            log.InfoFormat("Is connection string entity framework ? {0}",  isEntityFramework.ToString());
            if (isEntityFramework)
            {
                EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder(connectionString);
                connectionString = entityBuilder.ProviderConnectionString;
            }
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
            DataSource dbConnection = new DataSource()
            {
                Source = builder.DataSource,
                Catalog = builder.InitialCatalog
            };
            return dbConnection;
        }
    
