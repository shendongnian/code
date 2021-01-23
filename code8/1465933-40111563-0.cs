    public void EmailRO(string recipient, string attachmentPath)
    {
    
            var SMTP = new SmtpClient
            {
                Host = "YourHost",
                Port = 12345, //your port
                EnableSsl = true, // or false
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("YourUserName", "YourPassword")
            };
    
            Thread T1 = new Thread(delegate()
            {
                try 
                {
                    using (var message = new MailMessage("YourSmtpUserName", recipient)
                    {
                        Subject = "My Subject",
                        Body = "My Body",
                        From = new MailAddress("YourUserName", "YourDisplayName"),
                        IsBodyHtml = true
                    })
                    {
                        {
                            message.Attachments.Add(new Attachment("YourAttachmentPath"));
                            SMTP.Send(message);
                        }
                    }
                }
                catch (ArgumentException)
                {
                    // handle exception
                }
            });
            T1.IsBackground = true;
            T1.Start();
                
    }
