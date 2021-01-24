    public class EventsForceHub : Hub {
        public void NotifyUpdates(decimal val) {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<EventsForceHub>();
            if (Context != null) {
                string clientID = Context.ConnectionId;         // <-- on debug: Ok has conn id.
                object caller = Clients.Caller;                 // <-- on debug: Ok, not null
                object caller2 = Clients.Client(clientID);      // <-- on debug: Ok, not null
                Clients.Caller.updateProgress(val);             // Message sent
                Clients.Client(clientID).updateProgress(val);   // Message sent
            }
            if (hubContext != null) {
                //"updateProgress" is javascript event trigger name
                hubContext.Clients.All.updateProgress(val);     // Message sent
            }
        }
    }
