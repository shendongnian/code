     public static void OutLookMailStart(string EmailID, string password)
            {
                Microsoft.Office.Interop.Outlook.Application app = null;
                Microsoft.Office.Interop.Outlook._NameSpace ns = null;
                Microsoft.Office.Interop.Outlook.PostItem item = null;
                Microsoft.Office.Interop.Outlook.MAPIFolder inboxFolder = null;
                Microsoft.Office.Interop.Outlook.MAPIFolder subFolder = null;
                Microsoft.Office.Interop.Outlook.MailItem mailItem = null;
    
             
                try
                {
                    app = new Microsoft.Office.Interop.Outlook.Application();
                    ns = app.GetNamespace("MAPI");
    
                    ns.Logon(EmailID, password, true, true);
    
                    inboxFolder = ns.Folders[EmailID].Folders[2];
    
                    foreach (Microsoft.Office.Interop.Outlook.MailItem mailItemm in inboxFolder.Items)
                    {
                        if (mailItemm.UnRead) // I only process the mail if unread
                        {
                            // Email Subject 
                            Console.WriteLine("Subject : {0}", mailItemm.Subject);
                            string Subject = mailItemm.Subject;
                            if (!string.IsNullOrEmpty(Subject) && !string.IsNullOrWhiteSpace(Subject))
                            {
                                if (Subject.Contains(FileDomain))
                                {
                                  
                                  
                                    var SenderName = mailItemm.Sender.Name;
                                    //Email Body
                                    Console.WriteLine("Accounts: {0}", mailItemm.Body);
                                 
    
                                 
    
                                    // Read All Attachements  
                                    var attachments = (mailItemm as MailItem).Attachments;
                                    if (attachments != null && attachments.Count > 0)
                                    {
                                        for (int i = 1; i <= attachments.Count; i++)
                                        {
                                            attachments[i].SaveAsFile(tempFolderPath + (mailItemm as MailItem).Attachments[i].FileName);
      
    
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    ns.Logoff();
                    inboxFolder = null;
                    subFolder = null;
                    mailItem = null;
                    app = null;
                }
            }
