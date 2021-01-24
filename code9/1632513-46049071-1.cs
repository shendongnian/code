    public Doc()
    {
        _Ms = new MemoryStream();
        _Wpd = WordprocessingDocument.Create(_Ms, WordprocessingDocumentType.Document, true);
        _Wpd.AddMainDocumentPart();
        _Wpd.MainDocumentPart.Document = new DocumentFormat.OpenXml.Wordprocessing.Document();
        _Wpd.MainDocumentPart.Document.Body = new Body();
        _Wpd.MainDocumentPart.Document.Save();
        _Wpd.Package.Flush();
    }
