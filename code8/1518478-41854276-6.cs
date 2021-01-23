    public override Task OnConnected()
    {
        Trace.WriteLine(Context.ConnectionId + ' - reconnected');
        return base.OnConnected();
    }
