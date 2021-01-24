    string[] connections = new string[] {
                    "Data Source=localhost;Integrated Security=SSPI;Initial Catalog=DB1",
                    "Data Source=localhost;Integrated Security=SSPI;Initial Catalog=DB2"}; 
    foreach (string strConnection in connections)
         {
              string serverName = "str" + DateTime.Now.Ticks;
              var sqlStorage = new Hangfire.SqlServer.SqlServerStorage(strConnection);
              var options = new BackgroundJobServerOptions
                {
                    ServerName =serverName  
                };
              JobStorage.Current = sqlStorage;
              IBackgroundJobClient client = new BackgroundJobClient();
              Hangfire.States.IState state = new Hangfire.States.EnqueuedState
                    {
                        Queue = serverName
                    };  
              client.Create(() => Console.WriteLine(serverName), state); 
         }
