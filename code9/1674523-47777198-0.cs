    public async void Button_Click(object sender, RoutedEventArgs args )
    {
        object result = await EnterWaitingRoom( "whatever" );
    }
    
    private Task<object> EnterWaitingRoom(string val)
    {
        return InvokeHubMethod(
            "HubMethod",
            new object[] { val } );
    }
    
    private Task<object> InvokeHubMethod(string method, object[] args)
    {
        return _hubProxy.Invoke<object>(
            method, 
            args);
    }
