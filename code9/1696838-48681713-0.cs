    foreach (var item in task.Result)
    {
        IEnumerable<FileItem> subItems = null;
        FileItem subItem = null;
        try
        {
            FileItem retFile = item.ToFileItem();
            logger.Info("Going Into " + retFile.Path);
            if (item.IsFolder == true)
            {
                subItems = FilesToDownload(retFile);
            }
            else
            {
                subItem = retFile;
            }
        }
        catch { /* your code here */ }
        if (subItem != null) yield return subItem;
        if (subItems != null)
        {
            foreach (var x in subItems) yield return x;
        }
    }
