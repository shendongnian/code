    Document document = new Document(MyDir + "in.html");
    var builder = new DocumentBuilder(document);
    HeaderFooter header = builder.CurrentSection.HeadersFooters[HeaderFooterType.FooterPrimary];
    if (header == null)
    {
        header = new HeaderFooter(builder.CurrentSection.Document, HeaderFooterType.FooterPrimary);
        builder.CurrentSection.HeadersFooters.Add(header);
    }
    
    builder.MoveToHeaderFooter(HeaderFooterType.HeaderPrimary);
    
    builder.PageSetup.PageStartingNumber = 1;
    builder.PageSetup.RestartPageNumbering = true;
    
    builder.MoveToHeaderFooter(HeaderFooterType.HeaderPrimary);
    //Use following line to get the required output. 
    builder.ParagraphFormat.Alignment = ParagraphAlignment.Right;
    builder.InsertField("PAGE", string.Empty);
    builder.MoveToDocumentEnd();
    
