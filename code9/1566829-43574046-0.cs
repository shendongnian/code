    wordApp = new Microsoft.Office.Interop.Word.Application();
    newDoc = wordApp.ActiveDocument;
    doc = wordApp.Documents.Open(@"C:\Users\user\Desktop\test.docx");  
    if(newDoc!=null) 
      newDoc.Activate();
