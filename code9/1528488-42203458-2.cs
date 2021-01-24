    using (PdfReader pdfReader = new PdfReader(inputPath))
    using (PdfStamper pdfStamper = new PdfStamper(pdfReader, outputStream))
    {
        PdfArray vertices = new PdfArray(new int[]{ 100, 100, 300, 300, 100, 300, 300, 100 });
        PdfAnnotation polyLine = PdfAnnotation.CreatePolygonPolyline(pdfStamper.Writer, pdfReader.GetPageSize(1),
            "", false, vertices);
        polyLine.Color = BaseColor.GREEN;
        pdfStamper.AddAnnotation(polyLine, 1);
    }
