    public class MySmtpClient : ISmtpClient
    {
        public void Send(MailMessage msg, string host, int port, SmtpDeliveryMethod deliveryMethod)
        {
            using (var client = new SmtpClient())
            {
                client.Host = SmtpHost;
                client.Port = SmtpPort;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(mail);
            }
        }
    }
    public class MailMessageComposer : IMailMessageComposer
    {
        public MailMessage Create(string noReplyEmailAddress, string emailAddress, string subject, string body, bool isHtml)
        {
            return new new MailMessage(noReplyEmailAddress, emailAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = isHtml
            };
        }
    }
