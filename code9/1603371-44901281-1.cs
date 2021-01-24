    public class EmailService : IIdentityMessageService
    {
        public async Task<string> SendAsync(IdentityMessage message)
        {
            string body = ONMailStyles.getOpening();
            body += message.Body;
            var mailService = new Mail(message.Destination, message.Subject, body);
            string success = await mailService.send();
            return success;
        }
    }
