    [HubName("MailHub")]
    public class MailHub<THub>: Hub
        where THub : IHub
    {
        public void SendMessage (Mail message)
        {
            var sendMessage = new Mail
            {
                Subject = message.Subject,
                Sender = message.Sender,
                Receiver = message.Receiver,
                Message = message.Message
            };
            await _mail.CreateAsync(sendMessage);
        }
    }
