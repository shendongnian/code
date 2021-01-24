    public static DocX Create(string filename, 
        DocumentTypes documentType = DocumentTypes.Document)
    {
        // Store this document in memory
        MemoryStream ms = new MemoryStream();
        // Create the docx package
        //WordprocessingDocument wdDoc = WordprocessingDocument.Create(ms, 
            DocumentFormat.OpenXml.WordprocessingDocumentType.Document);
        Package package = Package.Open(ms, FileMode.Create, FileAccess.ReadWrite);
        PostCreation(package, documentType);
        DocX document = DocX.Load(ms);
        document.filename = filename;
        return document;
    }
