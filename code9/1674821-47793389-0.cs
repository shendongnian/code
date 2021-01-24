    public class MyHub : Hub
    {
        private static IHubContext context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
            
        public override Task OnConnected()
        {      
            //Here check the list if this is going to be our first client and if so call your method, next time because our list is filled your method won't be invoked.
            if(UserHandler.UserList.Count==0)
                UpdateClient(true);
            UserHandler.UserList.Add(Context.ConnectionId)     
            return base.OnConnected();
        }
        public override Task OnDisconnected(bool stopCalled)
        {   
            UserHandler.UserList.RemoveAll(u => u.ConnectionId == Context.ConnectionId);
            return base.OnDisconnected(stopCalled);
        }
    }
