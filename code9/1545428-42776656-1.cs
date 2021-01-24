    var table = new PdfPTable(2) 
    { 
        HorizontalAlignment = Element.ALIGN_LEFT,
        WidthPercentage = 50 
    };
    var cell = new PdfPCell() {HorizontalAlignment = Element.ALIGN_CENTER};
    using (var stream = new MemoryStream())
    {
        using (var document = new Document())
        {
            PdfWriter.GetInstance(document, stream);
            document.Open();
    
            for (int i = 0; i < rows; ++i)
            {
                cell.BackgroundColor = i % 2 == 0
                    ? BaseColor.LIGHT_GRAY : BaseColor.WHITE;
                for (int j = 0; j < columns; ++j)
                {
                    cell.Phrase = new Phrase(data[i, j].ToString());
                    table.AddCell(cell);
                }
            }
            document.Add(table);
        }
        File.WriteAllBytes(OUTPUT, stream.ToArray());
    }
