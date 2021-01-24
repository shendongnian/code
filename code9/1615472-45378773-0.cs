    string oldpath = @"C:\Files\sample_new.pdf";
    string newpath = @"C:\Files\sample_new_1.pdf";
    PdfReader reader = new PdfReader(oldpath);
    iTextSharp.text.Rectangle size = reader.GetPageSizeWithRotation(1);
    Document doc = new Document(size);
    FileStream fs = new FileStream(newpath, FileMode.Create, FileAccess.Write);
    PdfWriter writer = PdfWriter.GetInstance(doc, fs);
    doc.Open();
    PdfContentByte cb = writer.DirectContent;
    PdfImportedPage page = writer.GetImportedPage(reader, 1);
    cb.AddTemplate(page, 0, 0);
    foreach (var list in jobpath)
    {
        doc.NewPage();
        doc.Open();                    
        PdfPTable table = new PdfPTable(1);
        table.HorizontalAlignment = Element.ALIGN_CENTER;
        table.TotalWidth = 400f;
        float[] widths = new float[] { 2f };
        table.SetWidths(widths);
        table.SpacingBefore = 40f;
        table.SpacingAfter = 30f;
        PdfPCell cell = new PdfPCell();
        cell.Colspan = 3;
        cell.HorizontalAlignment = 1;
        table.AddCell(list);
        doc.Add(table);
    }
    doc.Close();
