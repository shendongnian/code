    using (var redisConnection = ConnectionMultiplexer.Connect(...))
    {
        var server = redisConnection.GetServer(endpoint:...);
    
        if (server != null)
        {
             foreach (var key in server.Keys(pattern: "Error.*"))
             {
                   redisConnection.Database.KeyDelete(key);
             }
        }
    }
