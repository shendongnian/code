    public async Task Acceptor(TcpListener listener)
    {
      for (;;)
      {
        TcpClient client = await listener.AcceptTcpClientAsync();
        OnConnectionAccepted(client).ContinueWith(task => { errorHandling }, OnlyOnFaulted);
        // some logic which will stop this loop if necessary
      }
    }
 
    private async Task OnConnectionAccepted(TcpClient client)
    {
      await HandleClientRequest(client);
      // .. further logic
    }
