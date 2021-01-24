    protected void Application_Start()
        {
            Conversation.UpdateContainer(
                builder =>
                {
                    builder.RegisterModule(new AzureModule(Assembly.GetExecutingAssembly()));
                     
                    // Using Azure Table for storage
                    var store = new TableBotDataStore(ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString);
 
                    builder.Register(c => store)
                        .Keyed<IBotDataStore<BotData>>(AzureModule.Key_DataStore)
                        .AsSelf()
                        .SingleInstance();
                });
 
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
