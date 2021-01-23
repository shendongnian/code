     public bool SendSupportEmail(string fromMailID, string toMailID, string subject, string body)
            {
    
                bool brv = true;
    
                try
                {
                    SmtpClient smtpClient = new SmtpClient();
                    //smtpClient.EnableSsl = true;
                    MailMessage message = new MailMessage();
                    message.From = new MailAddress(fromMailID.ToString());
                    message.To.Add(toMailID);
                    message.Subject = subject;
                    message.IsBodyHtml = true;
                    message.Body = body;
                    log.Info("From Addres-> " + fromMailID.ToString());
                    log.Info("To Addres-> " + toMailID);
                    smtpClient.Send(message);
                }
                catch (Exception ex)
                {
                    log.Info("From Addres-> " + fromMailID.ToString());
                    log.Info("To Addres-> " + toMailID);
                    //log.Info("CC Addres-> " + EmailId);
                    log.Error("Error:  " + ex.Message + "\nStrace: " + ex.StackTrace);
                    brv = false;
    
                }
                return brv;
            }
