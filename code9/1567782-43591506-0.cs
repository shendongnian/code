    private void ThisAddIn_Startup(object sender, System.EventArgs e)
    {
        this.Application.ItemSend += new Microsoft.Office.Interop.Outlook.ApplicationEvents_11_ItemSendEventHandler(Application_ItemSend);
    }
    void Application_ItemSend(object Item, ref bool Cancel)
    {
        if (Item is Outlook.MailItem)
        {
            Form1 f = new Form1();
            f.Show();
        }
    }
