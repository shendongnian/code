    using Word=Microsoft.Office.Interop.Word;
    ....
    Word.Application wordApp = new Word.Application();
    Word.Document document = wordApp.Documents.Open("C:\\myDoc.docx");
    int fileCount = 0;
    
    foreach (Word.InlineShape tempLoopVar_varObj in wordApp.ActiveDocument.InlineShapes)
    {
        if (tempLoopVar_varObj.Type == Word.WdInlineShapeType.wdInlineShapeEmbeddedOLEObject)
        {
            fileCount++;
        }
    }
