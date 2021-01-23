    public class MyHub : Hub
    {
        public void Send(string user)
        {
            Clients.All.addMessage(user);
        }
    }
