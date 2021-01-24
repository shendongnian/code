    Document doc = new Document();
         DocumentBuilder builder = new DocumentBuilder(doc);     
         Aspose.Words.Style style = doc.Styles.Add(StyleType.Paragraph, "newStyle");
         style.IsQuickStyle = true;
         style.Font.Size = 24;
         style.Font.SizeBi= 24;
         style.Font.Name = "B Mitra";
         style.Font.NameBi= "B Mitra";
    
     builder.ParagraphFormat.Style = style;  
        builder.Writeln("سلام");
