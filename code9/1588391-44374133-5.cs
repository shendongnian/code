    public static List<UserConnection> ListUser { get; set; }
    public static void SendNotification(string who)
    {
        IHubContext context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();  
        // Get specific user from connected ones.
        string Id = ListUser.Find(x => x.UserId == who).ConnectionId;
        context.Clients.Client(Id).addNotification(who); // or another data
    }
    //Add every connected users to the list
    public override Task OnConnected()
        {
            ListUser = new List<UserConnection>();
            var us = new UserConnection();
            us.UserId = Context.QueryString["UserId"];
            us.ConnectionId = Context.ConnectionId;
            ListUser.Add(us);
            return base.OnConnected();
        }
