    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            Clients.All.addNewMessageToPage(name, message);
        }
    
        public void mySend(string message)
        {
            Clients.All.addNewMessageToPage("webrole", message);
        }
    }
