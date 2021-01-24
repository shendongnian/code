    public class EmailService : IIdentityMessageService
    {
        Task IIdentityMessageService.SendAsync(IdentityMessage message)
        {
            return this.SendAsync(message);
        }
    
        public Task<string> SendAsync(IdentityMessage message)
        {
            string body = ONMailStyles.getOpening();
            body += message.Body;
            Mail mailService = new Mail(message.Destination, message.Subject, body);
            string succes = mailService.send();
            return Task.FromResult(succes);
        }
    }
