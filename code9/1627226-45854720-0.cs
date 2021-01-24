    [FunctionName("AzureFunction")]
    public static void Run([TimerTrigger("0 */2 * * * *")]TimerInfo myTimer, TraceWriter log)
    {
        log.Info($"C# Timer trigger function executed at: {DateTime.Now}");
        try
          {
             var authorizationSettings = new AuthorizationSettings
             {
                ApplicationKey = Guid.NewGuid().ToString(), //I have no application key
                ClientKey = Guid.NewGuid().ToString(), //I have no client key
                TokenStore = new BasicTokenStore("my.tokenstore")
              };
              var goApi = new Go(authorizationSettings);
            }
            catch (Exception e)
            {
               log.Info($"Exception:{e.Message}"); 
            }
              
            log.Info($"C# Timer trigger function Finished at: {DateTime.Now}");
    }
