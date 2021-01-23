    public static void SaveCopyAs(this Document doc, string path)
    {
        var persistFile = (System.Runtime.InteropServices.ComTypes.IPersistFile)doc;
        persistFile.Save(path, false);
    }
 
