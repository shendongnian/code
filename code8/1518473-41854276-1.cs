    public override Task OnDisconnected(bool stopCalled)
    {
        // do the logging here
        Trace.WriteLine(message + " - " + Context.ConnectionId);
        return base.OnDisconnected(stopCalled);
    }
