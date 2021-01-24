    public override System.Threading.Tasks.Task OnConnected()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            string userName = Context.User.Identity.Name;
            var allUsers = db.Users.ToList();
            var messages = db.Chats.ToList();
            Clients.Caller.connected(userName, allUsers, messages);
            return base.OnConnected();
         }
