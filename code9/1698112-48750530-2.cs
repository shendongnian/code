    using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(destinationFile, true))
    {
    	var body = wordDoc.MainDocumentPart.Document.Body;
    
    	var para = body.AppendChild(new Paragraph());
    	var run = para.AppendChild(new Run());
    
    	var txt = "Document Signed by: LocEngineer";
    	run.AppendChild(new Text(txt));
    	wordDoc.Save();
    }
