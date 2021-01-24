    private static string _connectionString = "name=ShipBob_DevEntities";
        static ShipBob_DevEntities()
        {
            if(!string.IsNullOrEmpty(System.Environment.GetEnvironmentVariable("AzureFunction")))
            {
                var connectionString = System.Environment.GetEnvironmentVariable("EntityFrameworkConnectionString");
                if (!string.IsNullOrEmpty(connectionString))
                {
                    _connectionString = connectionString;
                }
            }
        }
        public ShipBob_DevEntities()
            : base(_connectionString)
        {
            this.Configuration.LazyLoadingEnabled = false;
        }  
  
