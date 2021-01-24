    MemoryStream stream = new MemoryStream();
    PdfWriter writer = new PdfWriter(stream);
    PdfReader reader = new PdfReader(bytes);
    PdfDocument pdfDoc = new PdfDocument(reader, writer);
    Document document = new Document(pdfDoc);
    Rectangle pageSize;
    PdfCanvas canvas;
    int n = pdfDoc.GetNumberOfPages();
    for (int i = 1; i <= n; i++) {
        PdfPage page = pdfDoc.GetPage(i);
        pageSize = page.GetPageSize();
        canvas = new PdfCanvas(page);
        // draw page numbers on the canvas
    }
    pdfDoc.close();
