    public class ChatHub : Hub
    {
        public static ConcurrentDictionary<string, string> Connections = new ConcurrentDictionary<string, string>();
        public void Send(string username, string message)
        {
            string connectionToSendMessage;
            Connections.TryGetValue(username, out connectionToSendMessage);
            if (!string.IsNullOrWhiteSpace(connectionToSendMessage))
            {
                Clients.Client(connectionToSendMessage).SendMessage(message);
            }
        }
        public override Task OnConnected()
        {
            if (!Connections.ContainsKey(Context.ConnectionId))
            {
                Connections.TryAdd(Context.QueryString["UserName"], Context.ConnectionId);
            }
            return base.OnConnected();
        }
    }
