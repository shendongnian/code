    public override Task OnConnected()
        {
            Groups.Add(Context.ConnectionId, "foobar");
            return base.OnConnected();
        }
