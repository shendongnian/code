    public async void SendEmail(string mailTo, string mailFrom, string cc, string subject, string message)
    {
        var emailMessage = new MimeMessage();
        if (cc != null)
        {
            emailMessage.Cc.Add(new MailboxAddress(cc)); 
        }
        emailMessage.From.Add(new MailboxAddress("SenderName", "UserName"));
        emailMessage.To.Add(new MailboxAddress("mailTo"));
        emailMessage.Subject = subject;
        var builder = new BodyBuilder { TextBody = message };
        
        //Fetch the attachments from db
        //considering one or more attachments
        if (attachments != null)
        {
            foreach (var attachment in attachments.ToList())
            {
                builder.Attachments.Add(new Attachment(new MemoryStream(attachment), attachmentName, attachmentType));
            }
        }
        emailMessage.Body = builder.ToMessageBody();
        using (var client = new SmtpClient())
        {
            var credentials = new NetworkCredential
            {
                UserName = "USERNAME",
                Password = "PASSWORD"
            };
            await client.AuthenticateAsync(credentials);
            await client.ConnectAsync("smtp.gmail.com", 587).ConfigureAwait(false);
            await client.SendAsync(emailMessage).ConfigureAwait(false);
            await client.DisconnectAsync(true).ConfigureAwait(false);              
        }   }      
