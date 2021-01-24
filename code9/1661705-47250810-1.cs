    Word.Application winword = new Application();
    Word.Document document = winword.Documents.Open("C:\\myDoc.docx");
    int fileCount = 0;
    
    foreach (InlineShape tempLoopVar_varObj in winword.ActiveDocument.InlineShapes)
    {
       if (tempLoopVar_varObj.Type == WdInlineShapeType.wdInlineShapeEmbeddedOLEObject)
       {
           fileCount++;
       }
    }
