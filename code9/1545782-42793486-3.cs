    string[] headers = new string[]
    { 
        "Order Id", "Customer Id", "Customer Name", "Product Id",
        "Product Description", "Quantity", "Product Received"
    };
    Font font = new Font(Font.FontFamily.COURIER, 14, Font.ITALIC);
    font.Color = BaseColor.BLUE;
    var table = new PdfPTable(headers.Length) { WidthPercentage = 100 };
    table.SetWidths(GetHeaderWidths(font, headers));
    
    using (var stream = new MemoryStream())
    {
        using (var document = new Document(PageSize.A4.Rotate()))
        {
            PdfWriter.GetInstance(document, stream);
            document.Open();
            for (int i = 0; i < headers.Length; ++i)
            {
                table.AddCell(new PdfPCell(new Phrase(headers[i], font)));
            }
            document.Add(table);
        }
        File.WriteAllBytes(OUT_FILE, stream.ToArray());
    }
