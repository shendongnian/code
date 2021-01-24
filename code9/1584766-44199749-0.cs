    protected void SendAlertEmail(string smtpserver, string smtpport, string smtpuser, string smtppass, int ssl, int auth, string subject, string from, string to, string body)
            {
                try
                {
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress(SplitEmailStrging(from), HttpUtility.HtmlDecode(Request.Form["senderName"]));
                    string emails = to;
    
                    if (emails.Contains(","))
                    {
                        string[] emailslist = Regex.Split(emails, @",");
                        foreach (string email in emailslist)
                        {
                            mail.To.Add(SplitEmailStrging(email));
                        }
    
                    }
                    else
                    {
                        if (emails.Contains("<"))
                        {
    
                            mail.To.Add(SplitEmailStrging(emails));
                            // Response.Write(SplitEmailStrging(emails));
                        }
                        else
                        {
    
                            mail.To.Add(emails);
                            // Response.Write(emails);
                        }
    
                    }
                    
                    mail.Subject = subject;
                    mail.IsBodyHtml = true;
                    mail.Body = HttpUtility.HtmlDecode(body);
                    SmtpClient client = new SmtpClient(smtpserver);
    
                    if (int.Parse(smtpport) == 465)
                    {
                        client.Port = 25;
                    }
                    else
                    {
                        client.Port = int.Parse(smtpport);
                    }
    
                    if (ssl == 1)
                    {
                        client.EnableSsl = true;
                    }
                    else
                    {
                        client.EnableSsl = false;
                    }
    
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(smtpuser, smtppass);
                    client.UseDefaultCredentials = false;
                    client.Credentials = credentials;
                    client.Send(mail);
                }
                catch (Exception ex)
                {
                    Response.Write("Error: " + ex.InnerException.Message);
                    Response.End();
                }
    
    
            }
