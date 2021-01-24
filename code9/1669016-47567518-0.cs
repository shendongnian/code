     public class ChatHub : Hub<ITypedHubClient>
          {
            public void Send(string name, string message)
            {
              Clients.All.BroadcastMessage(name, message);
            }
          }
