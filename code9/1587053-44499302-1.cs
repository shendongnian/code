    private static Lazy<ConfigurationOptions> configOptions
        = new Lazy<ConfigurationOptions>(() => 
        {
            var configOptions = new ConfigurationOptions();
            configOptions.EndPoints.Add("x.x.x.1:6379");          
            configOptions.EndPoints.Add("x.x.x.2:6379");
            configOptions.EndPoints.Add("x.x.x.3:6379");
          
            configOptions.ClientName = "LeakyRedisConnection";
            configOptions.ConnectTimeout = 100000;
            configOptions.SyncTimeout = 100000;
            return configOptions;
        });
    private static string getIP()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                return ip.ToString();
            }
        }
        throw new Exception("ip not found!");
    }
    private static Lazy<ConfigurationOptions> getOptionsForIp(string myip)
            {
                var configOptions = new ConfigurationOptions();
                configOptions.EndPoints.Add(myip);
                configOptions.ClientName = "LeakyRedisConnectionDirectVM";
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
                string myIP = getIP();
                conn = ConnectionMultiplexer.Connect(getOptionsForIp(myIP).Value);
                if(conn == null || !conn.IsConnected){
                    conn = ConnectionMultiplexer.Connect(configOptions.Value);
                }
            }
            return conn;
        }
    }
