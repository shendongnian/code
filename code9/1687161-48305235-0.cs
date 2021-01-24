    using System.Net;
    using System.Net.Mail;
    string smtpAddress = "smtp.mail.yahoo.com";
    int portNumber = 587;
    bool enableSSL = true;
    string emailFrom = "email@yahoo.com";
    string password = "abcdefg";
    string emailTo = "someone@domain.com";
    string subject = "Hello";
    string body = "Hello, I'm just writing this to say Hi!";
    using (MailMessage mail = new MailMessage())
    {
        mail.From = new MailAddress(emailFrom);
        mail.To.Add(emailTo);
        mail.Subject = subject;
        mail.Body = body;
        mail.IsBodyHtml = true;
        // Can set to false, if you are sending pure text.
        mail.Attachments.Add(new Attachment("C:\\SomeFile.txt"));
        mail.Attachments.Add(new Attachment("C:\\SomeZip.zip"));
        using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
        {
            smtp.Credentials = new NetworkCredential(emailFrom, password);
            smtp.EnableSsl = enableSSL;
            smtp.Send(mail);
        }
    }
