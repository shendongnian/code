    public void PostMessageToUser(string ConnectionId)
    {
        var mappingHub = GlobalHost.ConnectionManager.GetHubContext<MessagingHub>();
    
        // Like this
        mappingHub.Clients.Client(ConnectionId).onMessageRecorded();
    
        // or this
        mappingHub.Clients.Clients(new List<string>() { ConnectionId }).onMessageRecorded();
    }
