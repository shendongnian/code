     [Authorize]
        public class YourHub: Microsoft.AspNetCore.SignalR.Hub
        {
    
              public override async Task OnConnectedAsync()
              {
                 ...
                 var identity = (ClaimsIdentity)Context.User.Identity;
              }
      }
 
