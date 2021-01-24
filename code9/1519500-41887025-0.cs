        try
        {
            using (var attachment = new Attachment(thisimage))
            using (var mail = new MailMessage())
            {
                mail.From = new MailAddress(emailaddress);
                mail.To.Add("xxxx@frontier.com");
                mail.Subject = thistitle;
                mail.Body = thisdescription;
                mail.Attachments.Add(attachment);
    
                using (var client = new SmtpClient("smtp.frontier.com"))
                {
                    client.Port = 25;
                    client.Credentials = new System.Net.NetworkCredential("username", "xxxxxxx");
                    client.EnableSsl = true;
                    client.Send(mail);
                }
            }
    
            MessageBox.Show("Mail sent");
        }
        catch (SmtpException ex)
        {
            // go read through https://msdn.microsoft.com/en-us/library/swas0fwc(v=vs.110).aspx
            // go read through https://msdn.microsoft.com/en-us/library/system.net.mail.smtpexception(v=vs.110).aspx
        }
    #if DEBUG
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Email Error Message");
        }
    #endif
    }
