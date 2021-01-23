    public void SendPacketToAll()
    {
        foreach (Client client in this.clients)
            client.socket.Send(...);
    }
    public void SendPacketToUserById(int id)
    {
        foreach (Client client in this.clients)
            if (client.Id == id)
                client.socket.Send(...);
    }
