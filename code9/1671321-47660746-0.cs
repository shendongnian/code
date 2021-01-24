    [HubName("Statistics")]
    public class Statistics : Hub
    {
        public Task Send(string message)
        {
            return Clients.All.InvokeAsync("Send", message);
        }
    }
