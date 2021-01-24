    PdfPTable table = new PdfPTable(2);
    PdfPCell cell1 = new PdfPCell(new Phrase("Cell A"));
    cell1.BackgroundColor = BaseColor.YELLOW;
    table.AddCell(cell1);
    PdfPCell cell2 = new PdfPCell(new Phrase("Cell B"));
    cell2.BackgroundColor = BaseColor.GREEN;
    table.AddCell(cell2);
