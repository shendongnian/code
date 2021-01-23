     internal DateTime GetContentCreatedDate()
     {
            Word.Document doc = Globals.ThisAddIn.Application.ActiveDocument;
            Office.DocumentProperties properties = (Office.DocumentProperties)doc.BuiltInDocumentProperties;
            return (DateTime)properties[Word.WdBuiltInProperty.wdPropertyTimeCreated].Value;
     }
