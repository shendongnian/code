    public class YourHub : Hub {
          public void MessageSender(int userId, string message)
            {
            //here you need to get the unique connectionId of a user
            //just make a query to the database for this
            Clients.Client(user.ConnectionId).sendMessage(message)
                
            }
    }
