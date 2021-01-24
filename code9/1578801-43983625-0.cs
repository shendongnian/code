     private bool EnvoieCourriel(string adrCourriel, string corps, string objet, string envoyeur, Attachment atache)
        {
            SmtpClient smtp = new SmtpClient();
            MailMessage msg = new MailMessage
            {
                From = new MailAddress(envoyeur),
                Subject = objet,
                Body = corps,
                IsBodyHtml = true
            };
            if (atache != null)
                msg.Attachments.Add(atache);
            try
            {
                msg.To.Add(adrCourriel);
                smtp.Send(msg);
            }
            catch(Exception e)
            {
               var erreur = e.Message;
                return false;
            }
            return true;
        }
