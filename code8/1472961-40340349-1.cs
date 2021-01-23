    // Actual content
    PdfReader overlay = new PdfReader("overlay.pdf");
    int n = overlay.NumberOfPages;
    PdfStamper stamper = new PdfStamper(overlay,
        new FileStream("result.pdf", FileMode.Create);
    // Company stationery (letter head)
    PdfReader stationery = new PdfReader("source.pdf");
    PdfImportedPage page = stamper.GetImportedPage(stationery, 1);
    // Add stationery page to each page of real content
    PdfContentByte background;
    for (int i = 1; i <= n; i++) {
         background = stamper.GetUnderContent(i);
         background.AddTemplate(page, 0, 0);
    }
    // Close the stamper
    stamper.Close();
