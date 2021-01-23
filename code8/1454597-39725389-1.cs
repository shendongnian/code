    if (!file.StartsWith("~$"))
    {   
        var wordApplication = new Microsoft.Office.Interop.Word.Application();
        var document = wordApplication.Documents.Open(file);    
    }
