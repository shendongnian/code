    public override Task OnReconnected()
    {
        Trace.WriteLine(Context.ConnectionId + ' - reconnected');
        return base.OnReconnected();
    }
