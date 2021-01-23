    Try using MailMessage class in System.Net.Mail namespace. You can append a HTML string to the body of the email.
    
    MailMessage msg = new MailMessage();
    msg.IsBodyHtml = true;
    msg.Body = bodyMessage.ToString();
    
    SmtpClient client = new SmtpClient();
    //other client settings
    client.Send(msg);
