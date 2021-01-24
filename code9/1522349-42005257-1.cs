       public string SendEmail(string To, string Subject, string MessageBody, Microsoft.Bot.Connector.Attachment attachment)
        {
            try
            {HttpClient httpClient = new HttpClient();
            MailMessage message = new MailMessage(EntityValues.FromEmail, To, Subject, MessageBody);
            if (attachment != null)
           { System.Net.Mail.Attachment data = new System.Net.Mail.Attachment(attachment.Name);
             
             message.Attachments.Add(data);
           }
