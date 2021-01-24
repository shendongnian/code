    public class MySmtpClient : ISmtpClient
    {
        public void Send(MailMessage msg, string host, int port, SmtpDeliveryMethod deliveryMethod)
        {
            using (var client = new SmtpClient())
            {
                client.Host = host;
                client.Port = port;
                client.DeliveryMethod = deliveryMethod;
                client.Send(msg);
            }
        }
    }
    public class MailMessageComposer : IMailMessageComposer
    {
        public MailMessage Create(string noReplyEmailAddress, string emailAddress, string subject, string body, bool isHtml)
        {
            return new MailMessage(noReplyEmailAddress, emailAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = isHtml
            };
        }
    }
