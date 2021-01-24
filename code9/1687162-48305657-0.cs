    string smtpAddress = "smtp.mail.yahoo.com";
            int portNumber = 587;
            bool enableSSL = true;
            string emailFrom = "elahi2mahdi@yahoo.com";
            string password = "password";
            string emailTo =message.Destination;
            string subject = message.Subject;
            string body = message.Body;
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(emailFrom);
                mail.To.Add(emailTo);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                // Can set to false, if you are sending pure text.
                //mail.Attachments.Add(new Attachment("C:\\SomeFile.txt"));
                //mail.Attachments.Add(new Attachment("C:\\SomeZip.zip"));
                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(emailFrom, password);
                    smtp.EnableSsl = enableSSL;
                   return smtp.SendMailAsync(mail);
                }
            }
