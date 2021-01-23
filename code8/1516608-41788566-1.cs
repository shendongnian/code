          [HubName("MailHub")]
        public class MailHub<THub>: Hub
              where THub : IHub
        {
        // change to static
        public static void SendMessage (Mail message)
        {
           IHubContext context = GlobalHost.ConnectionManager.GetHubContext<MailHub>();
           context.Clients.All.addMessage(message);
         }
    }
