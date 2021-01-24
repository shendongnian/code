    public string SendEmail(string fromEmail,
        string fromName,
        string toEmail,
        string subject,
        string content)
    {
        try
        {
            // Get, Set Variables
            MimeMessage Email = new MimeMessage();
            Email.From.Add(new MailboxAddress(fromName, fromEmail));
            Email.To.Add(new MailboxAddress("", toEmail));
            Email.Subject = subject;
            Email.Body = new TextPart("Plain") { Text = content };
            // SMTP Mail Client
            using (var client = new SmtpClient())
            {
                // Accept all SSL certificates (in case the server supports STARTTLS)
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.Connect(
                    "smtp.gmail.com",
                     587,
                    MailKit.Security.SecureSocketOptions.StartTlsWhenAvailable);
                    // Since we don't have an OAuth2 token, disable the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                // Only needed if the SMTP server requires authentication
                client.Authenticate("user@gmail.com", "password");
                client.Send(Email);
                client.Disconnect(true);
                return "Success";
            }
        }
        catch (Exception)
        {
            return "Failed";
        }
    }
