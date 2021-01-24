    public Task DoCallback(IHubContext<MyHub> hubContext)
    {
       var clients = m_hubContext.Clients as IHubClients<IMyHubClient>;
       clients.Client( "one").myCallback("Hi!");
    }
