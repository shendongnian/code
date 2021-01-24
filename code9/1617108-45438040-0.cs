    Document doc = new Document();
    FileStream fs = new FileStream(@"your path", FileMode.Create, FileAccess.Write);
    PdfWriter writer = PdfWriter.GetInstance(doc, fs);
    doc.Open();
    List<string> columns = new List<string> {"col1", "col2", "col3", "col4", "col5"};
    PdfPTable table = new PdfPTable(columns.Count);
    table.SetWidths(new[] { 5f, 5f, 5f, 5f, 5f });
    table.WidthPercentage = 100;
    table.TotalWidth = 500f;
    foreach (string col in columns)
    {
        PdfPCell cell = new PdfPCell(new Phrase(col));
        table.AddCell(cell);
    }
    
    for (int i = 0; i < 100; i++)
    {
        for (int j = 0; j < columns.Count; j++)
        {
            PdfPCell cell = new PdfPCell(new Phrase($"{i},{j}"));
            table.AddCell(cell);
        }
    }
    doc.Add(table);
    doc.Close();
