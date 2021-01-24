        public async Task SendEmailAsync(string toEmail, string title, string body, string attachmentPath)
        {
            try
            {
                // class to hold all values from the section system.net/mailSettings/smtp in app.config
                MailConfiguration smtpSection = new MailConfiguration();
                using (MailMessage mailMsg = new MailMessage("<" + smtpSection.FromAddress + ">", toEmail))
                {
                    mailMsg.IsBodyHtml = true;
                    mailMsg.Subject = title;
                    mailMsg.SubjectEncoding = Encoding.UTF8;
                    mailMsg.Body = body;
                    mailMsg.BodyEncoding = Encoding.UTF8;
                    if (!string.IsNullOrWhiteSpace(attachmentPath) && File.Exists(attachmentPath))
                    {
                        Attachment attachment = new Attachment(attachmentPath);
                        mailMsg.Attachments.Add(attachment);
                    }
                    using (SmtpClient smtpClient = new SmtpClient())
                    {
                        smtpClient.Timeout = 1000000;
                        smtpClient.UseDefaultCredentials = false;
                        await smtpClient.SendMailAsync(mailMsg);                       
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SendEmail exception: " + ex);
            }
            finally
            {                
                Console.WriteLine("SendEmail done");
            }
        }
