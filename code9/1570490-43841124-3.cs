    // client "storage"
    public static class ClientInfo  {
        public static Dictionary<string, MyAppClient> clients = new Dictionary<string, MyAppClient>();
        // .. further data and methods
    }
    // client type
    public class MyAppClient {
        public string Id { get; set; }
        public string Name { get; set; }
        // .. further prooerties and methods
        public MyAppClient(string id, string name) {
            Id = id;
            Name = name;
        }
    }
    // this a completely made up and dumb class to simulate slow process and give some simple progress events
    public static class MockupProgressGenerator {
        public static void DoJob(string clientName, int status) {
            if (status < 100) {
                Task.Delay(1000).ContinueWith(a =>
                {
                    EventsForceHub.NotifyUpdates(status += 20, clientName);
                    DoJob(clientName, status);
                });
            }
        }
    }
