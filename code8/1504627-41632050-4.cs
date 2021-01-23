    public interface IEmailSender
    {
        Task Send(
            string fromAddress,
            string fromName,
            string to,
            string subject,
            string message,
            IEnumerable<string> bcc = null);
    }
