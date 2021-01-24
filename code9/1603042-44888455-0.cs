    app = new Word.Application();
    
    object oMissing = System.Reflection.Missing.Value;
    Word._Document oDoc = app.Documents.Add(ref oMissing, ref oMissing,
    ref oMissing, ref oMissing);
.....
    app.ActiveDocument.SaveAs2(fileName);
