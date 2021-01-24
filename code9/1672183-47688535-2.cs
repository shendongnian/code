     try
     {
        var extensions = new List<string>();
        var files = Directory.GetFiles("F:\\WorkingCopy\\files\\", filename + ".*", System.IO.SearchOption.TopDirectoryOnly);
    
        foreach (var tmpfile in files)
           extensions.Add(Path.GetExtension(tmpfile));
    
    }
    catch (Exception ex)
    {
                throw ex;
    }
