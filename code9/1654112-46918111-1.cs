    using (ConnectionMultiplexer connection = ConnectionMultiplexer.Connect("redisIP:6379,allowAdmin=true"))
    {
          Model.SessionInstances = connection.GetEndPoints()
            .Select(endpoint =>
            {
                var status = new Status();
                var server = connection.GetServer(endpoint);
                status.IsOnline = server.IsConnected;
                return status;
            }).ToList();
     }
