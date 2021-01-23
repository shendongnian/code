    private void InitializeListiner()
    {
        var listener = new TcpListener(IPAddress.Any, ports);
        listener.Start();
        listener.BeginAcceptTcpClient(OnClientConnected, listener);
    }
    private void OnClientConnected(IAsyncResult asyncResult)
    {
        var listener = (TcpListener)asyncResult.AsyncState;
        var client = listener.EndAcceptTcpClient(asyncResult);
        listener.BeginAcceptTcpClient(OnClientConnected, listener);
        // ToDo: send and receive data from/to client...
    }
