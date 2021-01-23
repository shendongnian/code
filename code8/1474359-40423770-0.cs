    public class SendCustomText : Hub
    {
        public string myStatus;
        public static string myConnectionID;
        public void CurrentStatus()
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<SendCustomText>();
            context.Clients.Client(myConnectionID).setStatus(myStatus);
        }
        public override System.Threading.Tasks.Task OnConnected()
        {
            myConnectionID = Context.ConnectionId;
            return base.OnConnected();
        }
    }
