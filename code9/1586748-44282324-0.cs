                MailMessage msg = new MailMessage();
                msg.BodyEncoding = System.Text.Encoding.Default;
                msg.To.Add(ToEmail);
                msg.Priority = System.Net.Mail.MailPriority.High;
                msg.Subject = Subj;
                msg.Body = strBody;
                msg.IsBodyHtml = true;
                if (attachement != null)
                {
                    msg.Attachments.Add(attachement);
                }
                System.Net.Mail.AlternateView HTMLView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(strBody, HTMLType);
                msg.From = new MailAddress(StringConstant.MailFrom); // Your Email Id
                SmtpClient client = new SmtpClient(StringConstant.SmtpFrom, StringConstant.SmtpPort);
                client.Credentials = cred;
                client.EnableSsl = true;
                client.Send(msg);
