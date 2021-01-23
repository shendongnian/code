    static void Main(string[] args)
    {
        IPAddress ipAdress = IPAddress.Parse("192.160.1.8");
        // Initializes the Listener
        TcpListener tcpListener = new TcpListener(ipAdress, 8001);
        tcpListener.Start();
        int no;
        for (;;)
        {
            Socket socket = tcpListener.AcceptSocket();
            if (socket.Connected)
            {
                byte[] buffer = new byte[8000000];
                using (Stream os = File.OpenWrite("Target.jpg")) 
                {
                    using (NetworkStream networkStream = new NetworkStream(socket)) 
                    {
                        no = networkStream.Read(buffer, 0, 8000000);
                        os.Write(buffer, 0, no);
                    }
                }
                ///here the problem in the following line
                ///
                   Image i = Image.FromFile("Target.jpg");
                ///
                socket.Close();
                break;
            }
        }
    }
