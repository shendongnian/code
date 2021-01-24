       string strMailBody ="test";
       string strToEmailId ="da###dotnet@gmail.com";
       string strSubject = "Mail Testing";
       SmtpClient Client = new SmtpClient();
       Client.EnableSsl = true;
       System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
        message.To.Add("mail####hr@gmail.com");
                message.Bcc.Add(strToEmailId);// (ToEmailId);
                message.Subject = strSubject;// "Subject";
                message.IsBodyHtml = true;
                message.Body = strMailBody;//Content;
                try
                {
                    Client.Send(message);
                }
                catch (Exception ex)
                {
                    
                }
