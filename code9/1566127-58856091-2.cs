        App = new Microsoft.Office.Interop.Outlook.Application();
    
        MailItem mailItem = App.CreateItem(OlItemType.olMailItem);
    
        mailItem.Subject = Subject;
        mailItem.To = To;
        mailItem.CC = CC;
        mailItem.BCC = BCC;
        mailItem.Body = Body;
    
        // display the item before adding the attachments
        mailItem.Display();     // display the email
    
        // make sure a filename was passed
        if (string.IsNullOrEmpty(FileAtachment) == false)
        {
            // need to check to see if file exists before we attach !
            if (!File.Exists(FileAtachment))
                MessageBox.Show("Attached document " + FileAtachment + " does not exist", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Attachment attachment = mailItem.Attachments.Add("D:\\text.txt", Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue, Type.Missing, Type.Missing);
            }
         }
