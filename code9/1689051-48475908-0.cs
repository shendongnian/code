        private static UdpClient udpClient;
 
        static void Main(string[] args)
        {
            Console.WriteLine("Server initiated...");
            udpClient = new UdpClient(8888);
        }
 
        private static void ReadMessage()
        {
            while (true)
            {
                try
                {
                    IPEndPoint IPEP = null;
                    string message = Encoding.ASCII.GetString(udpClient.Receive(ref IPEP));
                }
            }
        }
        private static void SendUDP(IPEndPoint e,string message)
        {
            new UdpClient().Send(Encoding.ASCII.GetBytes(message), message.Length, e);
        }
 
