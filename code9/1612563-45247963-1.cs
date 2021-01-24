     public class MyHub : Hub
       {
           public void Announce(string connectionID, string userID)
           {
               Groups.Add(Context.ConnectionId, userID);
           }
       }
