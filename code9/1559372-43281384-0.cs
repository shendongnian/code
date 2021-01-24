    public class ChatHub : Hub
    {
        public static string LastUserConnectionId = "";
        public void Send(string User, string Message)
        {
            Clients.Client(LastUserConnectionId ).SendMessage(Message);
        }
        public override Task OnConnected()
        {
            LastUserConnectionId = Context.ConnectionId;
            return base.OnConnected();
        }
    }
