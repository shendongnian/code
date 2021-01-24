    private bool ConnectClient(SomeClient clientToConnect, IPAddress ipToConnectTo, int delay)
    {
        System.Threading.Thread.Sleep(delay);
        clientToConnect.Connect(ipToConnectTo);
        return clientToConnect.Connected;
    }
    
    try
    {
        bool successfulConnection;
    
        while (!successfulConnection)
        {
            successfulConnection = ConnectClient(yourClient, "10.10.10.10", 2000);
        }
    }
    catch
    {
    // ...
    }
