    public override Task OnConnected()
    {
        var onlineUserManager = NewOnlineUserManager<OnlineUser>(new OnlineUserStore<OnlineUser>(new ApplicationDbContext()));
        var onlineUser = onlineUserManager.FindByConnectionId(Context.ConnectionId);
        if (onlineUser == null)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindByName(Context.User.Identity.Name);
            onlineUser = new OnlineUser
            {
                ConnectionId = Context.ConnectionId,
                UserId = currentUser.Id
            };
            onlineUserManager.Save(onlineUser);
        }
        return base.OnConnected();
    }
    public override Task OnDisconnected(bool stopCalled)
    {
        if (stopCalled)
        {
            var onlineUserManager = NewOnlineUserManager<OnlineUser>(new OnlineUserStore<OnlineUser>(new ApplicationDbContext()));
            var onlineUser = onlineUserManager.FindByConnectionId(Context.ConnectionId);
            if (onlineUser != null)
            {
                onlineUserManager.Remove(onlineUser);
            }
        }
        return base.OnDisconnected(stopCalled);
    }
