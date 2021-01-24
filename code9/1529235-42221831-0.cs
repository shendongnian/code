        //Server Part
        public void Start()
        {
            Console.WriteLine("Server started...");
            TcpListener listener = new TcpListener(System.Net.IPAddress.Loopback, 1234);
            listener.Start();
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                new Thread(new ThreadStart(() =>
                {
                    HandleClient(client);
                })).Start();
            }
        }
      private void HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            StreamWriter writer = new StreamWriter(stream, Encoding.ASCII) { AutoFlush = true };
            StreamReader reader = new StreamReader(stream, Encoding.ASCII);
            string inputLine = reader.ReadLine();
            Console.WriteLine("The client with name " + " " + inputLine + " is conected");
  
        }
    //Client Part
     public void InitClient()
      {
            client = new TcpClient("localhost", 1234);
            stream = client.GetStream();
            writer = new StreamWriter(stream) { AutoFlush = true };
            reader = new StreamReader(stream);
      }
      
      public void SendMessage(string userName)
      {
         writer.WriteLine(userName);
      }
    
     //And here are the type of the variable that are used:
        TcpClient client;
        NetworkStream stream;
        StreamWriter writer;
        StreamReader reader;
