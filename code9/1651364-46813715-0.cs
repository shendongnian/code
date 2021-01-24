    void Start()
    {
        ConnectionConfig myConfig = new ConnectionConfig();
        myConfig.AddChannel(QosType.Unreliable);
        myConfig.AddChannel(QosType.UnreliableFragmented);
        myConfig.PacketSize = 1440;
        NetworkManager.connectionConfig = myConfig;
    }
