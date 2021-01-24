    System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
    message.To.Add("recipient@bar.com");
    message.Subject = "Important";
    message.From = new System.Net.Mail.MailAddress("sender@bar.com");
    message.Body = "Message";
    
    System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("your.exchange.instance.url");
    try
    {
    	smtp.Send(message);
    }
    catch (SmtpFailedRecipientException ex)
    {
    	throw ex;
    }
