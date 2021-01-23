    //initialize an instance
    Document document = new Document();
    //load a document
    document.LoadFromFile(@"Example.docx");
    Section section = document.Sections[0];
    //add page borders with special style and color
    section.PageSetup.Borders.BorderType = BorderStyle.DoubleWave;
    section.PageSetup.Borders.Color = Color.LightSeaGreen;
    //set the spaces between border and text
    section.PageSetup.Borders.Left.Space = 50;
    section.PageSetup.Borders.Right.Space = 50;
    //save
    document.SaveToFile("PageBorders.docx", FileFormat.Docx);
