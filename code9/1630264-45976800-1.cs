    using System;
    using System.IO;
    using System.Net.Mail;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace WebApplication1
    {
        public class Sender
        {
            public void SendEmail(string toEmail, string logMail, string title, string body, string attachmentPath)
            {
                var result = ActualEmailSend(toEmail, logMail, title, body, attachmentPath);
            }
    
            public async Task ActualEmailSend(string toEmail, string logMail, string title, string body, string attachmentPath)
            {
                var emailSender1 = SendEmailAsync(toEmail, title, body, attachmentPath);
                var emailSender2 = SendEmailAsync(logMail, "Copy of " + title, body, attachmentPath);
    
                await Task.WhenAll(emailSender1, emailSender2);
    
                if (!string.IsNullOrWhiteSpace(attachmentPath) && File.Exists(attachmentPath))
                {
                    File.Delete(attachmentPath);
                }
            }
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
        }
    }
