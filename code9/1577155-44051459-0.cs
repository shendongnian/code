    using Word = Microsoft.Office.Interop.Word;
    public void DrawShape()
    {
    try{
        var wordApp = new Word.Application();
        wordApp.Documents.Add(System.Type.Missing);
        Word.Document doc = wordApp.ActiveDocument;
        var shape = doc.Shapes.AddShape((int)Microsoft.Office.Core.MsoAutoShapeType.msoShapeRectangle, 20, 20, 60, 20);
       }
       catch(Exception ex) { }
    }
