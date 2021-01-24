    // Initializing the Transport Layer with no arguments (default settings)
    NetworkTransport.Init();
    
    // An example of initializing the Transport Layer with custom settings
    GlobalConfig gConfig = new GlobalConfig();
    gConfig.MaxPacketSize = 500;
    NetworkTransport.Init(gConfig);
    ConnectionConfig config = new ConnectionConfig();
    // use QosType.Reliable if you need TCP
    int myReiliableChannelId  = config.AddChannel(QosType.Reliable);
    // use QosType.Unreliable if you need UDP
    int myUnreliableChannelId = config.AddChannel(QosType.Unreliable);
    HostTopology topology = new HostTopology(config, 10);
    // set listen port 8888
    int hostId = NetworkTransport.AddHost(topology, 8888);
