    public class ChatHub: Hub {
     public void Send(string name, string message,string orderId) {
      // Call the addNewMessageToPage method to update clients.
      Clients.Group(orderId).addNewMessageToPage(name, message);
     }
    
    public void JoinOrderGroup(string name,string orderId)
     {
         Groups.Add(Context.ConnectionId, orderId);
     }
    }
