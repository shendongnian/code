    private void copyAlltoClipboard()
    {
        G2.SelectAll();
    
        DataObject dataObj = G2.GetClipboardContent();
        if (dataObj != null)
        {
            Clipboard.SetDataObject(dataObj);
            PrefixOtherDataToClipboard();
        }
    }
