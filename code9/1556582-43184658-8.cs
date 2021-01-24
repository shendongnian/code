    public class EmailService
    {
        private readonly ISmtpClient _smtpClient;
        private readonly IMailMessageComposer _mailMessageComposer;
        public EmailService(ISmtpClient smtpClient, IMailMessageComposer mailMessageComposer)
        {
            _smtpClient = smtpClient;
            _mailMessageComposer = mailMessageComposer;
        }
        public void SendEmail(string emailAddress, string subject, string body)
        {
            var message = _mailMessageComposer.Create(NoReplyEmailAddress, emailAddress, subject, body, true);
            _smtpClient.Send(message, SmtpHost, SmtpPort, SmtpDeliveryMethod.Network);
        }
    }
