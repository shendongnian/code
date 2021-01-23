    public class ExchangeEmailService : IIdentityMessageService {
        readonly IMailBoxProvider provider;
    
        public ExchangeEmailService(IMailBoxProvider provider) {
            this.provider = provider;
        }
    
        public async Task SendAsync(IdentityMessage message) {
            using (var client = new SmtpClient()) {
                client.Host = "mail.example.com";
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(@"noreply", "P@ssw0rd");
    
                //Get the body and from address
                var fromEmailAddress = "default-email@example.com";
                var body = message.Body;
                try {
                    var msg = JsonConvert.DeserializeObject<MessageBody>(body);
                    if(msg != null) {
                        body = msg.Body;
                        fromEmailAddress = provider.GetMailbox(msg.Source);
                    }
                } catch { }
    
                var from = new MailAddress(fromEmailAddress);
                var to = new MailAddress(message.Destination);
    
                var mailMessage = new MailMessage(from, to)
                {
                    Subject = message.Subject,
                    Body = body,
                    IsBodyHtml = true
                };
                await client.SendMailAsync(mailMessage);
            }
        }
    }
