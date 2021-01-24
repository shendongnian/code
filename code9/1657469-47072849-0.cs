    public override Task OnConnectedAsync()
    {
        Groups.AddAsync(Context.ConnectionId, Context.User.Identity.Name);  
        return base.OnConnectedAsync();
    }
