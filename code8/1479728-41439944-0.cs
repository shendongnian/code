    try
                {
                    MailMessage message = new MailMessage();
                    message.From = new MailAddress(ConfigurationManager.AppSettings["Sender"]);
                    message.To.Add(ConfigurationManager.AppSettings["Sender"]);
                    message.Subject = "Comentario de " + TB_nomcomplet.Text;
                    message.IsBodyHtml = false;
                    message.Body = TB_texteemail.Text;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = ConfigurationManager.AppSettings["SmtpHost"];
                    smtp.Credentials = new NetworkCredential("emailYours", "passwordYours");
                    smtp.Send(message);
    
                    LBL_messageEmail.Visible = true;
                }
                catch (Exception ex)
                {
                    LBL_messageEmail.Text = "Error: " + ex.Message;
                }
    
