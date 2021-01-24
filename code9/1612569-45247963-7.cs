     public class MyHub : Hub
       {
           public void Announce(string userID)
           {
               Groups.Add(Context.ConnectionId, userID);
           }
       }
