    PdfPTable table0 = new PdfPTable(5);
    float[] widths = new float[] { 7f, 0.5f, 4f, 0.5f, 7f };
    table0.SetWidths(widths);
    PdfPCell cell0 = new PdfPCell(new Phrase("a"));
    cell0.Rowspan = 2;
    cell0.VerticalAlignment = Element.ALIGN_MIDDLE;
    cell0.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right            
    table0.AddCell(cell0);
    cell0 = new PdfPCell(new Phrase(" = "));
    cell0.Rowspan = 2;
    cell0.VerticalAlignment = Element.ALIGN_MIDDLE;
    cell0.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right            
    table0.AddCell(cell0);
    cell0 = new PdfPCell(new Phrase("b"));
    cell0.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right            
    table0.AddCell(cell0);
    cell0 = new PdfPCell(new Phrase(" = "));
    cell0.Rowspan = 2;
    cell0.VerticalAlignment = Element.ALIGN_MIDDLE;
    cell0.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right            
    table0.AddCell(cell0);
    cell0 = new PdfPCell(new Phrase("a"));
    cell0.Rowspan = 2;
    cell0.VerticalAlignment = Element.ALIGN_MIDDLE;
    cell0.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right            
    table0.AddCell(cell0);
    cell0 = new PdfPCell(new Phrase("c"));
    cell0.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right            
    table0.AddCell(cell0);
    document.Add(table0);
