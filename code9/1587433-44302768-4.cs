    protected void SendEmail(string _subject, MailAddress _from, List<MailAddress> _cc, List<MailAddress> _bcc = null)
        {
            
            SmtpClient mailClient = new SmtpClient("mail.backlinkdesigns.co.za");
            MailMessage msgMail = new MailMessage(); ;
            var Text = "Good day" + "<br><br/>" + "I hope this message finds you well.";                
          
            msgMail.From = _from;
            var mailCollection = new MailAddressCollection()
            {
                new MailAddress("user@domain.co.za", "User Surbname"),
                new MailAddress("user@gmail.com", "Name Surname")
            };
          
            foreach (var mailAddress in mailCollection)
            {
                msgMail.To.Add(mailAddress);
            }
           
            foreach (MailAddress addr in _cc)
            {
                msgMail.CC.Add(addr);
            }
            if (_bcc != null)
            {
                foreach (MailAddress addr in _bcc)
                {
                    msgMail.Bcc.Add(addr);
                }
            }
            msgMail.Subject = _subject;
            msgMail.IsBodyHtml = true;
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(Text, new ContentType("text/html"));
            msgMail.AlternateViews.Add(htmlView);
            mailClient.Send(msgMail);
            msgMail.Dispose();
           
            MessageBox.Show("Your email has been successfully sent to " + mailCollection.Count + " users show below: " + "\n\n" + mailCollection[0].User + "\n" + mailCollection[1].User + "\n" + "\n\n" + "From: " + _from, "Message Status", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
        }
