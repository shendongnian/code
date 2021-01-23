    Paragraph p = new Paragraph("FOR YOUR RECORDS ONLY: DO NOT SUBMIT").SetFontSize(60);
    canvas.SaveState();
    PdfExtGState gs1 = new PdfExtGState().SetFillOpacity(0.2f);
    canvas.SetExtGState(gs1);
    document.ShowTextAligned(p, pageSize.GetWidth() / 2, pageSize.GetHeight() / 2, pdfDoc.GetPageNumber(page), TextAlignment.CENTER, VerticalAlignment.MIDDLE, 45);
    canvas.RestoreState();
