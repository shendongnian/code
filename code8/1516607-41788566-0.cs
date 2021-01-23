          [HubName("MailHub")]
        public class MailHub<THub>: Hub
              where THub : IHub
        {
        // change to static
        public static void SendMessage (Mail message)
        {
        Clients.Caller.addMessage(message);
         }
    }
