           static void Main(string[] args)
            {
                _token = GetToken(_tenantId, _applicationId, _applicationSecret);
                Console.WriteLine("Token acquired. Expires on:" + _token.ExpiresOn);
                // Instantiate management clients:
                _resourceMgmtClient = new ResourceManagementClient(new Microsoft.Rest.TokenCredentials(_token.AccessToken));
                _sqlMgmtClient = new SqlManagementClient(new TokenCloudCredentials(_subscriptionId, _token.AccessToken));
                DatabaseCreateOrUpdateResponse dbr = CreateOrUpdateDatabase(_sqlMgmtClient, _resourceGroupName, _serverName, _databaseName, _databaseEdition, _databasePerfLevel);
                Console.WriteLine("Database: " + dbr.Database.Id);
            }
            private static AuthenticationResult GetToken(string tenantId, string applicationId, string applicationSecret)
            {
                AuthenticationContext authContext = new AuthenticationContext("https://login.windows.net/" + tenantId);
                _token = authContext.AcquireToken("https://management.core.windows.net/", new ClientCredential(applicationId, applicationSecret));
                return _token;
            }
            static DatabaseCreateOrUpdateResponse CreateOrUpdateDatabase(SqlManagementClient sqlMgmtClient, string resourceGroupName, string serverName, string databaseName, string databaseEdition, string databasePerfLevel)
            {
                // Retrieve the server that will host this database
                Server currentServer = sqlMgmtClient.Servers.Get(resourceGroupName, serverName).Server;
    
                // Create a database: configure create or update parameters and properties explicitly
                DatabaseCreateOrUpdateParameters newDatabaseParameters = new DatabaseCreateOrUpdateParameters()
                {
                    Location = currentServer.Location,
                    Properties = new DatabaseCreateOrUpdateProperties
                    {
                        CreateMode = DatabaseCreateMode.PointInTimeRestore,
                        Edition = databaseEdition,
                        SourceDatabaseId = "/subscriptions/subscriptionId/resourceGroups/tomnewgroup/providers/Microsoft.Sql/servers/tomsunsqltest/databases/sourceDatabaseName",
                        RestorePointInTime  = DateTime.Parse("2017-02-09T02:28:20.21Z"),//Restore Point time
                        RequestedServiceObjectiveName = databasePerfLevel
                    }
                };
               
                DatabaseCreateOrUpdateResponse dbResponse = sqlMgmtClient.Databases.CreateOrUpdate(resourceGroupName, serverName, databaseName, newDatabaseParameters);
                return dbResponse;
            }
