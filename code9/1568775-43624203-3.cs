    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            new Email().Send(message);
            return Task.CompletedTask;
        }
    }
