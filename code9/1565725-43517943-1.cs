    public string Result 
    {
        set
        {
             _result=value;
             OnPropertyChanged(); 
        }
        get
        {
             return _result;
        }
    }
      public static async Task Connect(string ip, int port)
      {
            result = string.Empty;
            DnsEndPoint hostEntry = new DnsEndPoint(ip, port);
            Socket _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            SocketAsyncEventArgs socketEventArg = new SocketAsyncEventArgs();
            socketEventArg.RemoteEndPoint = hostEntry;
            socketEventArg.Completed += new EventHandler<SocketAsyncEventArgs>(delegate (object s, SocketAsyncEventArgs e)
            {
                result = e.SocketError.ToString();    
            });
           _socket.ConnectAsync(socketEventArg);
            await Task.Delay(1000); 
            Result=TCPConnection.result;
        }
