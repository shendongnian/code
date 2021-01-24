    using Outlook = Microsoft.Office.Interop.Outlook;        
    public partial class ThisAddIn
    {
        Outlook.NameSpace outlookNameSpace;
        Outlook.MAPIFolder inbox;
        Outlook.Items items;
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            outlookNameSpace = this.Application.GetNamespace("MAPI");
            inbox = outlookNameSpace.GetDefaultFolder(
                    Microsoft.Office.Interop.Outlook.
                    OlDefaultFolders.olFolderInbox);
            items = inbox.Items;
            items.ItemAdd +=
                new Outlook.ItemsEvents_ItemAddEventHandler(items_ItemAdd);
        }
        void items_ItemAdd(object Item)
        {
            Outlook.MailItem mail = (Outlook.MailItem)Item;
            if (Item != null)
            {
                Outlook.MailItem replyMail = mail.Reply();
                //Do your response
                mail.Send();
            }
        }
    }
