    while (true)
    {
        TcpClient client = listener.AcceptTcpClient();
        FireNewClientHasConnected(null, new NewClientConnectedEventArgs(client));
    }
