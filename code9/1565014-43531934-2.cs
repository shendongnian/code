    //[Outlook] is short for [Microsoft.Office.Interop.Outlook] 
            Outlook.Application outlook = new Outlook.Application();
            Outlook.MAPIFolder folder = outlook.GetNamespace("MAPI").GetDefaultFolder(Outlook.OlDefaultFolders.olFolderContacts);
            Outlook.Items items = folder.Items;
            foreach (var item in items) {
                if (item is Outlook.ContactItem) {
                    Outlook.ContactItem contact = item as Outlook.ContactItem;
                    string path = "";
                    Outlook.Attachment att = null;
                    if (!contact.HasPicture) { continue; }
                    path = @"C:\Temp\" + contact.EntryID + ".jpg";
                    att = contact.Attachments["ContactPicture.jpg"];
                    if (File.Exists(path)) {
                        File.Delete(path);
                    }
                    att.SaveAsFile(@"C:\Temp\" + contact.EntryID + ".jpg");
                }
            }
            GC.Collect();
