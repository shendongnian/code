    public Task SendEmail(string email, string subject, string body)
     {
     try
     {
     var mailClient = new SmtpClient
     {
     Host = "mail.mydomain.com",
     Credentials = new NetworkCredential("email@mydomain.com", "mypasword"),
     Port = myport,
     DeliveryMethod = SmtpDeliveryMethod.Network
     };
    
     var msg = new MailMessage("from email", email, subject,body) {IsBodyHtml = true};
     mailClient.Send(msg);
    
     return Task.FromResult(0);
     }
     catch (Exception ex)
     {
     return null;
     }
     }
