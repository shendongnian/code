    class WeatherClientManager
    {
      public async Task MainLoop()
      {
        TCPClient tcpClient = new TcpClient(GetTCPDetailsFromConfig())
        await tcpClient.ConnectAsync();
        CancellationTokenSource cts = new CancellationTokenSource();
        var receiveTask = Task.Run(()=>ReceiveTask(cts.Token));
        var keepaliveTask = Task.Run(()=>SendKeepAlive(cts.Token));
        await Task.WhenAll(receiveTask, keepaliveTask);
      }
    }
