    using System.Net.Mail;
    
    private void DispatchMail(string to)
    {
        var mail = new MailMessage
        {
            Subject = "subject",
            From = new MailAddress(@"sender email", @"sender name")
        };
        mail.To.Add(to);
        mail.Body = "your message body";
        var smtp = new SmtpClient(@"smtp mail server address");
        smtp.Port = 587;
        smtp.Credentials = new System.Net.NetworkCredential("username", "password");
        smtp.EnableSsl = true;
        smtp.Send(mail);
        mail.Dispose();
        smtp.Dispose();
    }
