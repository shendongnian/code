     public bool IsVisible(Office.IRibbonControl control)
        {
    string name = ((Outlook.Folder)control.Context).Name;
            if (foldername == "Inbox")
            {
                return false;
            }
            return true;
        }
