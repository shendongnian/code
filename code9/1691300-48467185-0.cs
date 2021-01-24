    private void SendMail(Outlook.Mailitem mail)
    {
       mail.SaveAs(tempDirectory + @"originalMail.msg");
       var folder = mail.SaveSentMessageFolder;  
       ChangeMailSubject(mail);
       ChangeMailText(mail);
       mail.Send();
       folder.Items.ItemAdd += new Outlook.ItemsEvents_ItemAddEventHandler((sender) => AttachOriginalMail(sender);    
    }
    
    private void AttachOriginalMail(object sender)
    {   
        var mail = (Outlook.MailItem) sender;
        mail.Attachments.Add(tempDirectory + @"originalMail.msg");
        mail.Save();
    }   
