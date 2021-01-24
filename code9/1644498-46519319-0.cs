    public static void Send(string from, string to, string cc, string subject, string message, string[] attachment, byte[] fileByte, string fileByteName)
            {
                string ccChar;
                if (!string.IsNullOrEmpty(cc) && cc.EndsWith(","))
                    ccChar = cc.Remove(cc.Length - 1, 1);
                else
                    ccChar = cc;
    
                if (smtp_address == "")
                {
                    smtp_address = ConfigurationManager.AppSettings["smtp_address"];
                    smtp_port = int.Parse(ConfigurationManager.AppSettings["smtp_port"]);
                    smtp_user = ConfigurationManager.AppSettings["smtp_user"];
                    smtp_password = ConfigurationManager.AppSettings["smtp_password"];
                    smtp_ssl = bool.Parse(ConfigurationManager.AppSettings["smtp_ssl"]);
                }
    
                MailMessage mm = new MailMessage(from, to, subject, message);
                mm.Bcc.Add(ConfigurationManager.AppSettings["mailAlertMonitor"]);
    
                mm.IsBodyHtml = true;
                if (!string.IsNullOrEmpty(ccChar)) mm.CC.Add(ccChar);
    
                if (fileByte.Length != 0 && !string.IsNullOrEmpty(fileByteName))
                {
                    mm.Attachments.Add(new Attachment(new MemoryStream(fileByte), fileByteName));
                }
    
                if (attachment != null)
                {
                    foreach (string file in attachment)
                    {
                        if (!string.IsNullOrEmpty(file))
                        {
                            Attachment attc = new Attachment(file);
                            mm.Attachments.Add(attc);
                        }
                    }
                }
    
                SmtpClient smtp = new SmtpClient(smtp_address, smtp_port);
                smtp.Credentials = new NetworkCredential(smtp_user, smtp_password);
                smtp.EnableSsl = smtp_ssl;
    
                smtp.Send(mm);
                InsertSendEmailLog(from, to, cc, ConfigurationManager.AppSettings["mailAlertMonitor"], subject, message);
            }
