    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            // I'm not familiar with "IdentityMessage". Let's assume for the sake
            // of this example that you can somehow adapt it to the "MailMessage"
            // type required by the "SmtpClient" object. That's a whole other question.
            // Here, "IdentityToMailMessage" is some hypothetical method you write
            // to handle that. I have no idea what goes inside that. :)
            using (MailMessage mailMessage = IdentityToMailMessage(message))
            using (SmtpClient smtpClient = new SmtpClient())
            {
                TaskCompletionSource<bool> taskSource = new TaskCompletionSource<bool>();
                // Configure "smtpClient" as needed, such as provided host information.
                // Not shown here!
    
                smtpClient.SendCompleted += (sender, e) => taskSource.SetResult(true);
                smtpClient.SendAsync(mailMessage, null);
    
                await taskSource.Task;
            }
        }
    }
