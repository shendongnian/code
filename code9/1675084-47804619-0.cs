    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            using (SmtpClient client = new SmtpClient())
            {
                await client.SendMailAsync("email from web config",
                                            message.Destination,
                                            message.Subject,
                                            message.Body);
            }
        }
    }
