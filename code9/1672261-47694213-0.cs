    using Word = Microsoft.Office.Interop.Word;
    var wdApp = new Word.Application();
    var documents = wdApp.Documents;
    var doc = documents.Open(newFile);
    doc.Content.Collapse(Word.WdCollapseDirection.wdCollapseEnd);
    doc.Content.InsertFile(file);
