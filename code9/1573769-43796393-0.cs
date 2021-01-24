    PdfContentByte cb = writer.DirectContent;
    PdfImportedPage page = writer.GetImportedPage(reader, 1);
    cb.AddTemplate(page, 0, 0);
    cb.BeginText();
    try
    {
        cb.SetFontAndSize(BaseFont.CreateFont(), 12);
        cb.SetTextMatrix(10, 100);
        cb.ShowText("Customer Name");
    }
    finally
    {
        cb.EndText();
    }
