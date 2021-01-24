     using System.Net.Mail;
    
    ...
    
    MailMessage mail = new MailMessage("xxxxx@hotmail.co.uk", "myname@businessemail.co.uk");
    SmtpClient client = new SmtpClient();
    client.Port = 25;
    client.DeliveryMethod = SmtpDeliveryMethod.Network;
    client.UseDefaultCredentials = false;
    client.Host = "smtp.live.com";
    mail.Subject = "Daily Email Check";
    mail.Body = "Email reached business exchange server from an external hotmail email account";
    client.Send(mail);
