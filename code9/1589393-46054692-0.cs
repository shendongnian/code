    static void Main(string[] args)
    {
        MyRemoteServerClass server = new MyRemoteServerClass();
        TcpChannel channel = new TcpChannel(8080);
        ChannelServices.RegisterChannel(channel, false);
        string uri = "MyRemoteServerClass";
        RemotingServices.Marshal(server, uri, server.GetType());
        System.Console.ReadLine();
    }
