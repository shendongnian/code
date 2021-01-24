    using (Stream output = new FileStream(@"TableWithColoredCellBackgrounds.pdf", FileMode.Create))
    using (Document document = new Document(PageSize.A4, 50, 50, 25, 25))
    {
        PdfWriter writer = PdfWriter.GetInstance(document, output);
        document.Open();
        PdfPTable table = new PdfPTable(2);
        PdfPCell cell1 = new PdfPCell(new Phrase("Cell A"));
        cell1.CellEvent = new ColorizeBackgroundEvent(BaseColor.YELLOW);
        table.AddCell(cell1);
        PdfPCell cell2 = new PdfPCell(new Phrase("Cell B"));
        cell2.CellEvent = new ColorizeBackgroundEvent(BaseColor.GREEN);
        table.AddCell(cell2);
        document.Add(table);
        document.Close();
    }
