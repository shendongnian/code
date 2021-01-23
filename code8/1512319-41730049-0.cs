    static void Main(string[] args) {
        string connection = "tcp://localhost:5555";
        using (var poller = new NetMQPoller()) {
            using (var server = new ResponseSocket()) {
                server.ReceiveReady += Server_ReceiveReady;
                poller.Add(server);
                poller.RunAsync();
                server.Bind(connection);
                // start 10000 clients
                for(int i = 0; i < 10000; i++) {
                    ParameterizedThreadStart parametrizedClientThread = new ParameterizedThreadStart(runClientSide);
                    Thread t = new Thread(parametrizedClientThread);
                    t.Start(connection);
                }
                Console.ReadLine(); //let server run until user pressed Enter key
            }
        }
    }
    //server (e.Socket) is receiving data here and can answer it
    private static void Server_ReceiveReady(object sender, NetMQSocketEventArgs e) {
        string fromClientMessage = e.Socket.ReceiveFrameString();
        Console.WriteLine("From Client: {0}", fromClientMessage);
        e.Socket.SendFrame("Hi Back");
    }
    private static void runClientSide(object param) {
        string connection = (string) param;
        using (var client = new RequestSocket()) {
            client.Connect(connection);
            client.SendFrame("Hello");
            
            //Removed server side code here and put it into ReceiveReady event
            string fromServerMessage = client.ReceiveFrameString();
            Console.WriteLine("From Server: {0}", fromServerMessage);
        }
    }
