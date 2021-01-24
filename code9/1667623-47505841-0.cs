    namespace SendEmail
    {
        class Email
        {
            public static void Main(string[] args)
            {
                try
                {
                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress("harish.1138@gmail.com");
                        mail.To.Add("harish_1138@yahoo.com");
                        mail.Subject = "Test Mail - 1";
                        mail.Body = "mail with attachment";
    
                        System.Net.Mail.Attachment attachment;
                        attachment = new System.Net.Mail.Attachment("C:\\EmailTest.xlsx");
                        mail.Attachments.Add(attachment);
    
                        using (SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com", 587))
                        {
                            SmtpServer.UseDefaultCredentials = false; //Need to overwrite this
                            SmtpServer.Credentials = new System.Net.NetworkCredential("harish.1138@gmail.com", "SamplePWD");
                            SmtpServer.EnableSsl = true;
                            SmtpServer.Send(mail);
                        }
                    }
                   
                    MessageBox.Show("Mail Sent");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
