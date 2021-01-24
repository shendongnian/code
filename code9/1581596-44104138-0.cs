      static void Main(string[] args)
            {
                //use result to wait the mehtod executed completely
                List<String> test =  getSqlDatabaseList().Result;
    
                foreach (var item in test)
                {
                    Console.WriteLine(item);
                }
              
                Console.Read();
    
            }
    
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
    
                var sqlServer = await azure.SqlServers.GetByResourceGroupAsync("groupname", "brandotest");
    
    
                var dbList = sqlServer.Databases.List();
    
                foreach (ISqlDatabase db in dbList)
                {
                    dbNameList.Add(db.Name);
                }
                return dbNameList;
            }
