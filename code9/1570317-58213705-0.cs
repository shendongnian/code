        Let us suppose you are using OutLook to send the emails:
        SmtpClient smtpClient = new SmtpClient("smtp-mail.outlook.com", 587); // 587 is 
        the port number for outlook
        smtpClient.Credentials = new 
        System.Net.NetworkCredential("yourActualEmailIDhere", "yourActualPassword");
        smtpClient.UseDefaultCredentials = true;
        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtpClient.EnableSsl = true;
        MailMessage mail = new MailMessage();
        //Setting From , To and CC
        mail.From = new MailAddress("yourActualEmailIDhere");
        mail.To.Add(new MailAddress("destinationEmailAddress"));       // for 'To' you 
        don't need any password credentials. So relax.
       smtpClient.Send(mail);  // finally send the email
