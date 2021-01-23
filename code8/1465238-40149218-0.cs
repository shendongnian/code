    using System.Net.Mail;
    
    ...
    
    MailMessage mail = new MailMessage("you@yourcompany.com", "user@hotmail.com");
    SmtpClient client = new SmtpClient();
    client.Port = 25;
    client.DeliveryMethod = SmtpDeliveryMethod.Network;
    client.UseDefaultCredentials = false;
    client.Credentials = new NetworkCredentials("user","pass");
    client.Host = "smtp.google.com";
    mail.Subject = "this is a test email.";
    mail.Body = "this is my test email body";
    client.Send(mail);
