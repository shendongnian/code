    var idList = new List<string>();
    foreach (var item in binFolder.Items.OfType<MailItem>())
    {
        try
        {
            idList.Add(item.EntryID);
        }
        catch (COMException ex)
        {
            Trace.WriteLine(ex);
        }
    }
