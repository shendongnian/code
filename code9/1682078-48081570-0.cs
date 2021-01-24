    [HubName("MyHubServer")]
    public class HubServer : Hub {
        public override Task OnConnected() {
            // My code OnConnected
            return base.OnConnected();
        }
        public override Task OnDisconnected(bool stopCalled) {
            // My code OnDisconnected
            return base.OnDisconnected(stopCalled);
        }
        public async Task<string> JoinGroup(string connectionId, string groupName) {
            await Groups.Add(connectionId, groupName);
            return connectionId + " joined " + groupName;
        }
        public async Task<string> LeaveGroup(string connectionId, string groupName) {
            await Groups.Remove(connectionId, groupName);
            return connectionId + " removed " + groupName;
        }
        public async Task<string> LeaveGroup(string connectionId, string groupName, string customerId = "0") {
            await Groups.Remove(connectionId, customerId);
            return connectionId + " removed " + groupName;
        }
    }
