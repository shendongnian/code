    public class ChatHub : Hub
    {
        public static string UserConnectionId = "";
        public void Send(string User, string Message)
        {
            Clients.Client(UserConnectionId ).SendMessage(Message);
        }
        public override Task OnConnected()
        {
            UserConnectionId = Context.ConnectionId;
            return base.OnConnected();
        }
    }
