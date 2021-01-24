    [Authorize]
    public class MessagingHub: Hub
    {
       public Task Send(string data)
      {
         var identity = (ClaimsIdentity)Context.User.Identity;
         //one can access all member functions or properties of identity e.g, Claims, Name, IsAuthenticated... 
          return Clients.Caller.SendAsync("Send", "Data To Send");
      }
    }
