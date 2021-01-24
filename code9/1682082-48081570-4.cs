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
            var message= connectionId + " joined " + groupName;
            Clients.Group("Associate").Notify(message);
            return message;
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
    class Program {
        static void Main(string[] args) {
            string url = "http://localhost:8080";
            using (WebApp.Start(url)) {
                Console.WriteLine("Server running on {0}", url);
                MainAsync(url).Wait();
                Console.ReadLine();
            }
        }
        static async Task MainAsync(string url) {
            try {
                var hubConnection = new HubConnection(url);
                IHubProxy stockTickerHubProxy = hubConnection.CreateHubProxy("MyHubServer");
                stockTickerHubProxy.On<string>("Notify",
                    data => Console.WriteLine("Notification received : {0}", data));
                await hubConnection.Start();
                var connectionId = hubConnection.ConnectionId;
                var response = await stockTickerHubProxy.Invoke<string>("JoinGroup", connectionId, "Associate");
                Console.WriteLine("Response received : {0}", response);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
    class Startup {
        public void Configuration(IAppBuilder app) {
            //app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
        }
    }
