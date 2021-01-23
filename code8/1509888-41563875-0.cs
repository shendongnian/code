    static void RemoveFiles(string sourceFilePath, string destFilePath)
    {
    
        try
        {
        // read src file
        FileStream inputStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read, FileShare.None);
        // open for reading
        PdfReader reader = new PdfReader(inputStream);
        FileStream outputStream = new FileStream(destFilePath, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
        PdfStamper stamper = new PdfStamper(reader, outputStream);
    
        // remove embedded files
        PdfDictionary root = reader.Catalog;
        PdfDictionary names = root.GetAsDict(PdfName.NAMES);
        names.Remove(PdfName.EMBEDDEDFILES);
    
        // close all
        stamper.Close();
        reader.Close();   
    
        }
        catch (Exception ex)
        {
        }
    
    }
