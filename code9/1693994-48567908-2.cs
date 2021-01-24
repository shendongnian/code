    var itemsToDelete = binFolder.Items.OfType<dynamic>().ToList();
    foreach (var item in itemsToDelete)
    {
        try
        {
            item.Delete();
        }
        catch (Exception ex)
        {
            Trace.WriteLine(ex);
        }
    }
