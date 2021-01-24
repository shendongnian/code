     public void SendDeviceActivationRequest(Stream ms, string fileName )
       {
                 //Here write your code to send Email and attach the pdf file as shown in below code.
                 MailMessage mail = new MailMessage();
                 System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(ms,fileName , "application/pdf");
                mail.Attachments.Add(attachment);
    }
