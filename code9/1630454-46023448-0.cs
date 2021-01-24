    var ms = new MemoryStream();
    var inputDoc = WordprocessingDocument.Create(ms, WordprocessingDocumentType.Document);
    
    MainDocumentPart inputMainPart = inputDoc.AddMainDocumentPart();
    inputMainPart.Document = new Document(new Body(new Paragraph(), new Paragraph()));
    input.Save();
    
    var outputDoc = input.Clone();
    outputDoc.RemovePart(outputDoc.MainDocumentPart);
    var outputMainPart = outputDoc.AddMainDocumentPart();
    
    
    var reader = OpenXmlReader.Create(inputMainPart);
    var writer = OpenXmlWriter.Create(outputMainPart);
    // write body/document
    
    reader.Read(); // read w:document
    reader.ReadFirstChild(); // read w:body
    reader.ReadFirstChild(); // read 1st w:p
    
    do {
        writer.WriteElement(new Table()); // insert w:tbl
        writer.WriteElement(reader.LoadCurrentElement());
    } while(reader.ReadNextSibling());
    doc.Save(); // observe only the 2 paragraphs in the `w:body`.
