    public class EmailController : MailerBase, IEmailService
    {
        public EmailResult PasswordRecovery(PasswordRecoveryModel model)
        {
            To.Add(model.Email);
            From = "noreply@example.com";
            Subject = "Password Recovery";
            return Email("PasswordRecovery", model);
        }
    }
