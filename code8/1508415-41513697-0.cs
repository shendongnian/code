    using MyOutlook= Microsoft.Office.Interop.Outlook;
      private void FindContactEmailByName(string firstName, string lastName)
            {
                Microsoft.Office.Interop.Outlook.Application outlook;
                outlook = new Microsoft.Office.Interop.Outlook.Application();
               
               MyOutlook.MAPIFolder contactsFolder =
               outlook.GetNamespace("MAPI").GetDefaultFolder(MyOutlook.OlDefaultFolders.olFolderContacts);
               MyOutlook.Items contactItems = contactsFolder.Items;
                try
                {
                    MyOutlook.ContactItem contact =
                        (MyOutlook.ContactItem)contactItems.
                        Find(String.Format("[FirstName]='{0}' and "
                        + "[LastName]='{1}'", firstName, lastName));
                    if (contact != null)
                    {
                        contact.Display(true);
                    }
                    else
                    {
                        MessageBox.Show("The contact information was not found.");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
