    void Explorer_SelectionChange()
    {
        if (this.Application.ActiveExplorer().Selection.Count == 1)
        {
            Outlook.MailItem item = this.Application.ActiveExplorer().Selection[1] as Outlook.MailItem;
            if (item != null)
            {
               //do something
            }
        }
    }
