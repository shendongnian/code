    using (HubConnection hubConnection = this.CreateHubConnection())
    {
        if (hubConnection != null)
        {
            using (LongPollingTransport lpTransport = newLongPollingTransport())
            {
                IHubProxy hubProxy = this.StartConnection(hubConnection, lpTransport);
                if (hubProxy != null && hubConnection.State == ConnectionState.Connected)
                {
                    await hubProxy.Invoke("MessageClients", messageArgs);
                }
            }
        }
    }
    private HubConnection CreateHubConnection()
    {
        // do some basic auth set up
        HubConnection hubConnection = new HubConnection(this.serverUrl);
        hubConnection.Headers.Add('authToken', basicAuth);
        return hubConnection;
    }
    private IHubProxy StartConnection(HubConnection hubConnection, HttpBasedTransport transport)
    {
        IHubProxy hubProxy = hubConnection.CreateHubProxy(this.hubName);
        Task t = Task.Run(() => hubConnection.Start(transport));
        t.WaitAndUnwrap();
        return hubProxy;
    }
