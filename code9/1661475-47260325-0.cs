    public static void DOCtoPDF(string docFullPath, string pdfFullPath)
    {
        DocumentModel wordDocument = DocumentModel.Load(docFullPath);
        wordDocument.Save(pdfFullPath);
    }
