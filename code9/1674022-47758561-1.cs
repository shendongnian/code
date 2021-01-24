    public class Server
    {
        //This is where the receiver connection will be stored
        public TcpClient ClientConnection { get; set; }
        public int Port { get; set; }
        public string Host { get; set; }
        public TcpListener Listener;
        public Server(int port,string host)
        {
             this.Port = port;
             this.Host = host;
        }
        public void Start()
        {
             this.Listener = new TcpListener(IPAddress.Parse(Host), Port);
             TryConnect();
        }
        public void TryConnect()
        {
             //You can use thread
             Task.Factory.StartNew(AcceptTheClientConnection, TaskCreationOptions.LongRunning);
        }
        public void AcceptTheClientConnection()
        {
            ClientConnection = this.Listener.AcceptTcpClient();
        }
        public void SendText(string text)
        {
             if (ClientConnection != null)
             {
                 try
                 {
                     var buffer = System.Text.Encoding.Default.GetBytes(text);
                     ClientConnection.Client.Send(buffer, SocketFlags.None);
                 }
                 catch(Exception e)
                 {
                     ClientConnection = null;
                     TryConnect();
                 }
             }
                else throw new InvalidOperationException("You must connect to client first");
        }
    }
