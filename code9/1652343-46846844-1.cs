    private async void HandleConnectionAsync(TcpClient tcpClient, Action<string> callback)
    {
        ..
        // Console.WriteLine(dataFromClient);
        callback(dataFromClient);
        ..
        
