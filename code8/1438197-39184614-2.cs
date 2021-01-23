    List<string> recipients = new List<string>();
        BackgroundWorker emailer = new BackgroundWorker();
        public void startSending()
        {
            emailer.DoWork += sendEmails;
            emailer.RunWorkerAsync();
        }
        private void sendEmails(object sender, DoWorkEventArgs e)
        {
            string attachmentPath = @"path to your PDF";
            string subject = "Give me a JOB!";
            string bodyHTML = "html or plain text = up to you";
            foreach (string recipient in recipients)
            {
                sendEmail(recipient, subject,bodyHTML,attachmentPath);
            }
        }
        private void sendEmail(string recipientAddress, string subject, string bodyHTML,string pathToAttachmentFile)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("your_email_address@gmail.com");
            mail.To.Add(recipientAddress);
            mail.Subject = subject;
            mail.Body = bodyHTML;
            System.Net.Mail.Attachment attachment;
            attachment = new System.Net.Mail.Attachment(pathToAttachmentFile);
            mail.Attachments.Add(attachment);
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("username", "password");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
           
        }
    
