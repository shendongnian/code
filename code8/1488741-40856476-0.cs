        List<string> emailTo = new List<string>();
                        emailTo.AddRange(receiverEmail.Split(',').ToList<string>()); // Create a list of To Addresses
                        using (MailMessage message = new MailMessage())
                        {
                            message.From = new MailAddress(emailFrom);
        					// Add each to address 
                            foreach (string EmailId in emailTo)
                            {
                                message.To.Add(new MailAddress(EmailId));
     //message.CC.Add(new MailAddress(EmailId)); // You can do the same thing for CC email
                            }
        
                            message.Subject = emailSubject;
                            message.IsBodyHtml = true;
                            message.Body = messageBody;
                            SmtpClient client = new SmtpClient();
                            client.Host = smtpHost;
                            client.Port = Convert.ToInt32(smtpPort);
                            client.Send(message);
                        }
