        public void AddTransactionLoggingCreatesConnection()
        {
 
            var servCollection = new ServiceCollection();
            //Add any injection stuff you need here
            //servCollection.AddSingleton(logger.Object);
 
            //Setup the MVC builder thats needed
            IMvcBuilder mvcBuilder = new MvcBuilder(servCollection, new Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager());
 
            IEnumerable<KeyValuePair<string, string>> confValues = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("TransactionLogging:Enabled", "True"),
                new KeyValuePair<string, string>("TransactionLogging:Uri", "https://api.something.com/"),
                new KeyValuePair<string, string>("TransactionLogging:Version", "1"),
                new KeyValuePair<string, string>("TransactionLogging:Queue:Enabled", "True")
            };
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddInMemoryCollection(confValues);
 
            var confRoot = builder.Build();
 
            StartupExtensions.YourExtensionMethod(mvcBuilder); // Any other params
        }
    }
