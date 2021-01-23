    private void AcceptTCPClient(IAsyncResult ar)
    {
        TcpListener Lis = (TcpListener)ar.AsyncState;
        Clients.Add(new ServerClient(Lis.EndAcceptTcpClient(ar)));
        StartLis(); // this will call BeginAcceptTcpClient again
    }
