    public void PostMessageToUser(string connectionId)
    {
        var mappingHub = GlobalHost.ConnectionManager.GetHubContext<MessagingHub>();
    
        // Like this
        mappingHub.Clients.Client(connectionId).onMessageRecorded();
    
        // or this
        mappingHub.Clients.Clients(new List<string>() { connectionId }).onMessageRecorded();
    }
