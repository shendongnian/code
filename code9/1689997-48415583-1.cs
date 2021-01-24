    var client = new TcpClient();
    HttpRequestInfo.AddTimestamp("Launching ConnectAsync");
    var connectAsyncTask = client.ConnectAsync(serverAddress, serverPort);
    HttpRequestInfo.AddTimestamp("ConnectAsync launched");
    HttpRequestInfo.AddTimestamp("Launching Delay");
    var delayTask= Task.Delay(TimeSpan.FromMilliseconds(300));
    HttpRequestInfo.AddTimestamp("Delay launched");
    var firstTask = await Task.WhenAny(connectAsyncTask, delayTask);
    if(firstTask == connectAsyncTask)
    { 
        HttpRequestInfo.AddTimestamp("Connected");
    }
    else
    {
        HttpRequestInfo.AddTimestamp("Timeout");
    }
