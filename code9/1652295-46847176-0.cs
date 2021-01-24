    // Change MemoryStream by FileStream
    public static SetCreator(FileStream inputStream, string newCreator)
    {
        using (WordprocessingDocument document = WordprocessingDocument.Open(inputStream, true))
        {
            document.PackageProperties.Creator = newCreator;
            // You shouldn't need to do document.Save()
        }
    }
    
    // Main code
    path = "C:\myPath";
    using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
    {
        SetCreator(fs, "ME");
    }
