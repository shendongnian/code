    using (PdfReader pdfReader = new PdfReader(inputPath))
    using (PdfStamper pdfStamper = new PdfStamper(pdfReader, outputStream))
    {
        Rectangle pageSize = pdfReader.GetPageSize(1);
        PdfArray vertices = new PdfArray(new int[] { 100, 100, 300, 300, 100, 300, 300, 100 });
        PdfAnnotation polyLine = PdfAnnotation.CreatePolygonPolyline(pdfStamper.Writer, pageSize,
            "", false, vertices);
        polyLine.Color = BaseColor.GREEN;
        PdfAppearance appearance = PdfAppearance.CreateAppearance(pdfStamper.Writer, pageSize.Width, pageSize.Height);
        appearance.SetColorStroke(BaseColor.RED);
        appearance.MoveTo(100, 100);
        appearance.LineTo(300, 300);
        appearance.LineTo(100, 300);
        appearance.LineTo(300, 100);
        appearance.Stroke();
        polyLine.SetAppearance(PdfName.N, appearance);
        pdfStamper.AddAnnotation(polyLine, 1);
    }
