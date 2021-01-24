    public List<Outlook.MailItem> GetMails()
    {
      Microsoft,Office.Interop.Outlook.NameSpace nameSpace = OutLookName.Application.GetNameSpace("MAPI");
      nameSpace.Logon("","",System.Reflection.Missing.Value,System.Reflection.Missing.Value);
      Microsoft.Office.Interop.Outlook.MAPIFolder inboxFolder = nameSpace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderInbox);
      List<Outlook.MailItem> eMails = new List<Outlook.MailItem>();
      
      foreach(Microsoft.Office.Interop.Outlook.MailItem mailItem in inboxFolder.Items)
      {
        if(mailItem.UnRead)
          eMails.Add(mailItem);
      }
    return eMails;
    }
