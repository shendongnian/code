     private void EnvoieCourriel(string adrCourriel, string text, string object, string envoyeur, Attachment atache)
        {
            SmtpClient smtp = new SmtpClient();
            MailMessage msg = new MailMessage
            {
                From = new MailAddress(envoyeur),
                Subject = object,
                Body = text,
                IsBodyHtml = true
            };
    
            if (atache != null)
                msg.Attachments.Add(atache);
    
                msg.To.Add(adrCourriel);
                smtp.Send(msg);
    
    
            return;
        }
