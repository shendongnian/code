    //[Outlook] is short for [Microsoft.Office.Interop.Outlook] 
            Outlook.Application outlook = new Outlook.Application();
            Outlook.MAPIFolder folder = outlook.GetNamespace("MAPI").GetDefaultFolder(Outlook.OlDefaultFolders.olFolderContacts);
            Outlook.Items items = null;
            items = folder.Items;
            foreach (var item in items) {
                if (item is Outlook.ContactItem) {
                    Outlook.ContactItem contact = null;
                    Outlook.Attachments atts = null;
                    Outlook.Attachment att = null;
                    string path = "";
                    contact = item as Outlook.ContactItem;
                    if (!contact.HasPicture) { continue; }
                    path = @"C:\Temp\" + contact.EntryID + ".jpg";
                    atts = contact.Attachments;
                    att = atts["ContactPicture.jpg"];
                    if (File.Exists(path)) {
                        File.Delete(path);
                    }
                    att.SaveAsFile(@"C:\Temp\" + contact.EntryID + ".jpg");
                    Marshal.ReleaseComObject(att);
                    att = null;
                    Marshal.ReleaseComObject(atts);
                    atts = null;
                    Marshal.ReleaseComObject(contact);
                    contact = null;
                }
            }
            if (items != null) {
                Marshal.ReleaseComObject(items);
                items = null;
            }
