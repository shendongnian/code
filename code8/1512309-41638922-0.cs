    static void Main(string[] args) {
            string IPAddr = "127.0.0.1";
            TcpListener listener = new TcpListener(new IPAddress(Encoding.UTF8.GetBytes(IPAddr)), 8080);
            listener.Start();
            while (true) {
                Task.Factory.StartNew(() => handleTCPResults(listener.AcceptTcpClient()));
            } 
        }
        static void handleTCPResults(TcpClient client) {
            var stream = client.GetStream();
        }
