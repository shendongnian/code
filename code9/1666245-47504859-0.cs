    var message = new MimeMessage();
    message.From.Add(new MailboxAddress("Tom Gmail", "xx@gmail.com"));
    message.To.Add(new MailboxAddress("Tom Hotmail", "xxx@hotmail.com"));
    message.Subject = "I am a mail subject";
    message.Body = new TextPart("plain")
    {
           Text = "I am a mail body."
    };
    
    using (var client = new SmtpClient())
    {
    
      client.Connect("smtp.gmail.com", 587);
      // Note: since we don't have an OAuth2 token, disable
      // the XOAUTH2 authentication mechanism.
      client.AuthenticationMechanisms.Remove("XOAUTH2");
      // Note: only needed if the SMTP server requires authentication
      client.Authenticate("sunguiguan@gmail.com", "@WSX3edc");
      client.Send(message);
      client.Disconnect(true);
      }
