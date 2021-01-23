    using System.Threading.Tasks
    public ServerTCP()
    {
        TcpListener listen = new TcpListener(IPAddress.Any, 1200);
        Console.WriteLine("Waiting");
        listen.Start();
        Task myTask = new Task(() =>
        {
            while (true)
            {
                TcpClient client = listen.AcceptTcpClient();
                Console.WriteLine("Client connected");
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[client.ReceiveBufferSize];
                int data = stream.Read(buffer, 0, client.ReceiveBufferSize);
                string message = Encoding.Unicode.GetString(buffer, 0, data);
                int idgiorno = Int32.Parse(message);
                Console.WriteLine("idgiorno: " + idgiorno);
                client.Close();
            }
        });
        myTask.Start();
    }
