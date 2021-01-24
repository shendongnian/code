    public class EventsForceHub : Hub {
        public static IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<EventsForceHub>();
        // allow users to join to hub and get s dedicated group/channel for them, so we can update them
        public async Task JoinGroup(string clientName) {
            string clientID = Context.ConnectionId;
            ClientInfo.clients.Add(clientID, new MyAppClient(clientID, clientName));
            await Groups.Add(clientID, clientName);
            // this is just mockup to simulate progress events (this uis not needed in real application)
            MockupProgressGenerator.DoJob(clientName, 0);
        }
       
        public static void NotifyUpdates(decimal val, string clientName) {
            // update the given client on his group/channel
            hubContext.Clients.Group(clientName).updateProgress(val);
        }
    }
