    void Start()
    {
        NetworkServer.Listen(9000);
        NetworkServer.RegisterHandler(MsgType.Connect, OnConnected);
        NetworkServer.RegisterHandler(MsgType.Disconnect, OnDisconnected);
        NetworkServer.RegisterHandler(MsgType.Error, OnError);
    }
    
    public void OnConnected(NetworkMessage netMsg)
    {
        Debug.Log("Client Connected");
    }
    
    public void OnDisconnected(NetworkMessage netMsg)
    {
        Debug.Log("Disconnected");
    }
    
    public void OnError(NetworkMessage netMsg)
    {
        Debug.Log("Error while connecting");
    }
