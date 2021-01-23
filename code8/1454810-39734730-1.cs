    class SocketWrapper
    {
        public Socket Socket { get; }
        public string Name { set; set; }
        public SocketWrapper(Socket socket)
        {
            Socket = socket;
        }
    }
