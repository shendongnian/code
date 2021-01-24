    Immediately after printing the header and the content...
    // Table for final footer.
    float[] cols = new float[] { 137, 10, 137, 10, 137, 10, 127 };
    PdfPTable f = new PdfPTable(7);
    f.SetWidthPercentage(cols, PageSize.A4);
    
    // Populate the table
    f.AddCell(pdfUtils.newCell("Lorem", detail_font_size, PdfPCell.ALIGN_CENTER, 1) );
    f.AddCell(pdfUtils.newCell(" ", detail_font_size, PdfPCell.ALIGN_CENTER, 0));
    f.AddCell(pdfUtils.newCell("Ipsum", detail_font_size, PdfPCell.ALIGN_CENTER, 1));
    f.AddCell(pdfUtils.newCell(" ", detail_font_size, PdfPCell.ALIGN_CENTER, 0));
    f.AddCell(pdfUtils.newCell("exquisitaque", detail_font_size, PdfPCell.ALIGN_CENTER, 1));
    f.AddCell(pdfUtils.newCell(" ", detail_font_size, PdfPCell.ALIGN_CENTER, 0));
    f.AddCell(pdfUtils.newCell("responsum", detail_font_size, PdfPCell.ALIGN_CENTER, 1));
    
    // Write the footer using absolute positioning.
    f.WriteSelectedRows(0, -1, prDoc.LeftMargin, 75, pdfWriter.DirectContent);
    // Close the document
    pdfWriter.CloseStream = false;
    prDoc.Close();
