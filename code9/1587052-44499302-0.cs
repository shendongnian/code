    private static Lazy<ConfigurationOptions> configOptions
        = new Lazy<ConfigurationOptions>(() => 
        {
            var configOptions = new ConfigurationOptions();
            configOptions.EndPoints.Add("localhost:6379");
            //add All endpoints here
            configOptions.EndPoints.Add("toto:6379");
            configOptions.EndPoints.Add("titi:6379");
            configOptions.EndPoints.Add("tutu:6379");
            configOptions.ClientName = "LeakyRedisConnection";
            configOptions.ConnectTimeout = 100000;
            configOptions.SyncTimeout = 100000;
            return configOptions;
        });
    private static ConnectionMultiplexer conn;
     
    private static ConnectionMultiplexer LeakyConn
    {
        get
        {
            if (conn == null || !conn.IsConnected){
                
                //lookup for localhost redis server here or another
                //conn = code here your private rules
                conn = ConnectionMultiplexer.Connect(configOptions.Value);
            }
            return conn;
        }
    }
