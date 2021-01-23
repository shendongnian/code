    // create document
    Document MigraDokument = new Document();
    // create section. 
    Section section = MigraDokument.AddSection();            
    section.PageSetup.PageFormat = PageFormat.A4;
    // create a table
    Table t = section.AddTable();
    // size to use for the image and the image cell in the table
    int size = 6;
    // create 3 columns
    Column column_header = t.AddColumn("6cm");
    column_header.Format.Alignment = ParagraphAlignment.Center;
    Column column_image = t.AddColumn(Unit.FromMillimeter(size));
    column_image.Format.Alignment = ParagraphAlignment.Center;
    Column column_text = t.AddColumn("4cm");
    column_text.Format.Alignment = ParagraphAlignment.Center;
    // Add 1 row to fill it with the content
    Row r = t.AddRow();
    // add you Header
    Paragraph header = r.Cells[0].AddParagraph("Heading");
    header.Format.Font.Bold = true;
    header.AddTab();
    
    // add the image            
    Image image = r.Cells[1].AddImage("../../logo.png"); 
    image.Height = Unit.FromMillimeter(size);
    // Add your Title
    r.Cells[2].AddParagraph("Title");
    // allign all of them
    r.Cells[0].VerticalAlignment = VerticalAlignment.Center;
    r.Cells[1].VerticalAlignment = VerticalAlignment.Center;
    r.Cells[2].VerticalAlignment = VerticalAlignment.Center;
