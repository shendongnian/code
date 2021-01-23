    // Settings class for the IVerificationSender implementation
    public class SmtpVerificationSenderSettings
    {
        public string MailHost { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool EnableSsl { get; set; }
        // etc
    }
    public class EmailVerificationSender : IVerificationSender
    {
        private readonly SmtpVerificationSenderSettings settings;
        public EmailVerificationSender(SmtpVerificationSenderSettings settings) {
            if (settings == null) throw new ArgumentNullException("settings");
            this.settings = settings;
        }
        public void SendVerification(User user) {
            using (var client = new SmtpClient(this.settings.MailHost, 25)) {
                smtpClient.EnableSsl = this.settings.EnableSsl;
                using (MailMessage mail = new MailMessage()) {
                    mail.From = new MailAddress("info@foo", "MyWeb Site");
                    mail.To.Add(new MailAddress(user.Email));
                    mail.Body = $"Hi {user.Name}, Welcome to our site.";
                    client.Send(mail);
                }
            }
        }
    }
