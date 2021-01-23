    [HubName("MailHub")]
    public class MailHub<THub>: Hub
        where THub : IHub
    {
        public void SendMessage (Mail message)
        {
            await _mail.CreateAsync(message);
        }
    }
