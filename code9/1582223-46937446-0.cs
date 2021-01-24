     public static void SendEmail(string toEmail, string subject, string body)
     {
        try
        {
            const string fromEmail = "yourEmail@YourDomain.com";
            var message = new MailMessage
            {
               From = new MailAddress(fromEmail),
               To = { toEmail },
               Subject = subject,
               Body = body,
               DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
            };              
            using (SmtpClient smtpClient = new SmtpClient("webmail.YourDomain.com")) 
            {                   
               smtpClient.Credentials = new NetworkCredential("yourEmail@YourDomain.com", "your email password");
               smtpClient.Port = 25;
               smtpClient.EnableSsl = false;  
               smtpClient.Send(message);
            }
        }
        catch (Exception excep)
        {
          //ignore it or you can retry .
        }
    }
