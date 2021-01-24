    public interface ISmtpClient
    {
        void Send(MailMessage msg, string host, int port, SmtpDeliveryMethod deliveryMethod);
    }
    public interface IMailMessageComposer
    {
        MailMessage Create(string noReplyEmailAddress, string emailAddress, string subject, string body, bool isHtml);
    }
