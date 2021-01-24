    public class EmailService : IIdentityMessageService
        {
            public System.Threading.Tasks.Task SendAsync(IdentityMessage message)
            {
                // Plug in your email service here to send an email.
                var mail = new MailMessage
                {
                    Subject = message.Subject,
                    Body = message.Body,
                    IsBodyHtml = true
                };
                mail.To.Add(message.Destination);
                mail.From = new MailAddress("me@mail.com","me");
                var smtp = new SmtpClient
                {
                    Host = "smtp.mail.com",
                    Port = 25,
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential("me@mail.com", "password"),
                    EnableSsl = true
                };
                // Enter seders User name and password
    
                smtp.Send(mail);
    
                return System.Threading.Tasks.Task.FromResult(0);
            }
