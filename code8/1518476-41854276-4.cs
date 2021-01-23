    public override Task OnDisconnected(bool stopCalled)
    {
        // do the logging here
        Trace.WriteLine(Context.ConnectionId + ' - disconnected');
        return base.OnDisconnected(stopCalled);
    }
