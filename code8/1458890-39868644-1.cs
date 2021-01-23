    List<Client> clients = new List<Client>();
    // incoming connection
    void AcceptConnection()
    {
        Client newClient = new Client(this, serverSocket.Accept());
        
        clients.Add(newClient);
    }
