    private void ThisAddIn_Startup(object sender, System.EventArgs e)
            {
                this.Application.NewMailEx += 
                    new Outlook.ApplicationEvents_11_NewMailExEventHandler(EmailHandler);
            }
    
            void EmailHandler(string EntryIDCollection)
            {
                Debug.WriteLine("NewMailEx fired.");
            }
    
            void items_ItemAdd(object Item)
            {
                Debug.WriteLine("New item event fired.");
                Outlook.MailItem mail = (Outlook.MailItem)Item;
                if (Item != null)
                {
                    if (mail.MessageClass == "IPM.Note")
                    {
                        Debug.WriteLine("New Email Arrived.");
                    }
                }
            }
