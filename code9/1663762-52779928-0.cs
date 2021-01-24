    [Authorize]
    public class MessagingHub: Hub
    {
        public Task Send(string data)
        {
            return Clients.Caller.SendAsync("Send", "Data To Send");
        }
    }
