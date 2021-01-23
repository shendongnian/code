            public class AuthMessageSender : IEmailSender, ISmsSender
    {
        private readonly IOptions<SmtpConfig> _smtpConfig;
        public IConfiguration Configuration { get; set; }
 
        public AuthMessageSender( IOptions<SmtpConfig> smtpConfig)
        {
            _smtpConfig = smtpConfig;
        }
        public async Task SendEmailAsync(string email, string subject, string message, string fullName)
        {
            try
            {
                var _email = _smtpConfig.Value.SmtpUserEmail;
                string _epass = _smtpConfig.Value.SmtpPassworrd;
                var _dispName = _smtpConfig.Value.EmailDisplayName;
                var myMessage = new MimeMessage();
                var builder = new BodyBuilder();
                myMessage.To.Add(new MailboxAddress(fullName ?? "User", email));
                myMessage.From.Add(new MailboxAddress(_dispName, _email));
                myMessage.Subject = subject;
                builder.HtmlBody = message;
                myMessage.Body = builder.ToMessageBody();
                using (SmtpClient smtp = new SmtpClient())
                {
                    bool UseSSL = true;
                    string Host = _smtpConfig.Value.SmtpHost;
                    int Port = _smtpConfig.Value.SmtpPort;
                    await smtp.ConnectAsync(Host, Port, UseSSL).ConfigureAwait(true);
                    smtp.AuthenticationMechanisms.Remove("XOAUTH2");
                    smtp.Authenticate(_email, _epass); // Note: only needed if the SMTP server requires authentication
                    await smtp.SendAsync(myMessage).ConfigureAwait(true);
                    await smtp.DisconnectAsync(true).ConfigureAwait(true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
