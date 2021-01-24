     public static async Task<List<String>> getSqlDatabaseList()
            {
                //System.Diagnostics.Debug.WriteLine("Starting to get database list");
                List<string> dbNameList = new List<string>();
    
                var credentials = SdkContext.AzureCredentialsFactory.FromFile(@"D:\Auth.txt");
    
                var azure = Azure
                    .Configure()
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                    .Authenticate(credentials)
                    .WithDefaultSubscription();
    
                var sqlServer = await azure.SqlServers.GetByResourceGroupAsync("brandosecondtest", "brandotest");
    
                IReadOnlyList<ISqlDatabase> dbList = null;
    
                Thread thread = new Thread(() => { dbList = sqlServer.Databases.List(); });
                thread.Start();
                //wait the thread
                thread.Join();
    
                foreach (ISqlDatabase db in dbList)
                {
                    dbNameList.Add(db.Name);
                }
                return dbNameList;
            }
