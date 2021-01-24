    // Remove all attachments
    var allIndexesList = mailItem.Attachments.Cast<Outlook.Attachment>().ToList();
    
    var descIndexes = allIndexesList.Select(a => a.Index).OrderByDescending(i => i).ToArray();
    
    foreach(var i in indexes)
    {
        try
        {
            mailItem.Attachments.Remove(i);
        }
        catch (COMException e)
        {
            MessageBox.Show(e.Message);
        }
    }
