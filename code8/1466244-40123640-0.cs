    public override Task OnReconnected()
    {
       string name = Context.User.Identity.Name;
       if (!_connections.GetConnections(name).Contains(Context.ConnectionId))
       {
           _connections.Add(name, Context.ConnectionId);
       }
       return base.OnReconnected();
    }
