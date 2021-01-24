    class Program
        {
            public static void Main(string[] args)
            {
                var listener = new TcpListener(IPAddress.Any, 80);
                listener.Start();
                while (true)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    MakeNewConnection(client);
                }
            }
    
            public static void MakeNewConnection(TcpClient client)
            {
                var thread = new Thread(NewClient);
                thread.Start(client);
            }
    
            public static void NewClient(object data)
            {
                var client = (TcpClient)data;
    
                string adress = client.Client.AddressFamily.ToString();
    
                Console.WriteLine("{0} has connected!", adress);
    
                NetworkStream ns = client.GetStream();
    
                while (true)
                {
                    byte[] receivedbuffer = new byte[8192];
    
                    int receivedbytes = ns.Read(receivedbuffer, 0, receivedbuffer.Length);
    
                    string message = Encoding.UTF8.GetString(receivedbuffer, 0, receivedbytes);
                    string newmessage = "The server received: " + message;
    
                    byte[] sendBuffer = Encoding.UTF8.GetBytes(newmessage);
                    ns.Write(sendBuffer, 0, sendBuffer.Length);
                }
            }
    
        }
