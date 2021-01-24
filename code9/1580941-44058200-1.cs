    private void ConnectToHub()
    {
        try
        {
            // this is a method in the proxy service class that tries to connect to the hub
            // it returns true if it was able to connect successfully
            this.connected = hubProxyService.AttempConnectionToHub();
            if (this.connected)
            {
                this.hubProxy = hubProxyService.HubProxy;
                this.hubConnection = hubProxyService.HubConnection
            }
        }
        catch
        {
            this.connected = false;
        }
    }
    private void MyMethodThatInvokesHubMethod()
    {
        // Do some stuff
        // ...
        // ...
        // ...
        if (this.hubConnection.State == ConnectionState.Disconnected)
        {
            this.ConnectToHub();
        }
        if (this.hubConnection.State == ConnectionState.Connected)
        {
            await this.hubProxy.Invoke("MyHubMethod", hubMethodArgs);
        }
    }
