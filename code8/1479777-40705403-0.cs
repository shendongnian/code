    For Ex.
    
    // Sends email using SMTP with default network credentials
    public static void SendEmailToCustomer(string To, string From, string BCC, string    Subject, string Body, bool IsBodyHtml, string attachedPath = "") {
       
        //create mail message
        MailMessage message = !string.IsNullOrEmpty(From) ? new MailMessage(From, To) : new MailMessage(From, To);
        //create mail client and send email
        SmtpClient emailClient = new SmtpClient();
    
        //here write your smtp details below before sending the mail.
        emailClient.Send(message);
        //Here you can dispose it after sending the mail
        message.Dispose();
    
        //Delete specific file after sending mail to customer
        if (!string.IsNullOrEmpty(attachedPath))
            DeleteAttachedFile(attachedPath);
    }
    //Method to delete attached file from specific path.
    private static void DeleteAttachedFile(string attachedPath) {
        File.SetAttributes(attachedPath, FileAttributes.Normal);
        File.Delete(attachedPath);
    }
