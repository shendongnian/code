    Image itextImage = RETRIEVE YOUR IMAGE AS ITEXTSHARP IMAGE;
    PdfPCell cell = new PdfPCell()
    {
        FixedHeight = (document.PageSize.Width - document.LeftMargin - document.RightMargin) / 4,
        CellEvent = new ImageEvent(itextImage)
    };
    PdfPTable table = new PdfPTable(1);
    table.WidthPercentage = 100;
    table.AddCell("Above the image");
    table.AddCell(cell);
    table.AddCell("Below the image");
    document.Add(table);
