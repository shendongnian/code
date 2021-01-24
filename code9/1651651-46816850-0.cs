    NetworkManager netMan;
    
    void Start()
    {
        netMan.connectionConfig.AddChannel(QosType.Reliable);
        netMan.connectionConfig.AddChannel(QosType.ReliableSequenced);
        netMan.connectionConfig.AddChannel(QosType.ReliableFragmented);
        netMan.connectionConfig.AddChannel(QosType.Unreliable);
        netMan.connectionConfig.AddChannel(QosType.UnreliableSequenced);
    }
