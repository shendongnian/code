    var m = new MailMessage { Subject = txtSubject.Text, IsBodyHtml = true, Body = emailOpeningLine + txtMessage.Text };
                try
                {
                    m.To.Add(new MailAddress("to");
                    m.From = new MailAddress("senders email address");
                    m.ReplyToList.Add("senders email address");
                    foreach (var attachment in Attactments)
                    {
                        m.Attachments.Add(new Attachment(attachment));
                    }
                    client.Send(m);
                    m.To.Clear();
                    m.Attachments.Clear();
                }
                catch (SmtpException esException)
                {
                    
                }
                catch (Exception ex)
                {
                    
                }
