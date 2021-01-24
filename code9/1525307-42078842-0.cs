    private async void OnClientConnected(object sender, EventArgs e)
    {
        await Task.Run(() => HandleClientConnected(object, e));
    }
    protected abstract Task HandleClientConnected(object sender, EventArgs e);
    
