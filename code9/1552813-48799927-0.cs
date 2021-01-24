    string dest = @"C:\publish\Pantone.pdf";
    string text = "This text is PANTONE 485 C.";
    using (var fileStream = new FileStream(dest, FileMode.Create))
    {
        var pdfDoc = new PdfDocument(new PdfWriter(fileStream));
        using (var doc = new Document(pdfDoc))
        {
            PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            var alternateSpace = new DeviceRgb(220, 36, 31);
            var tintTransform = new PdfFunction.Type2(
                new PdfArray(new[] { 0.0f, 1f }),
                null,
                new PdfArray(new[] { 1f, 1f, 1f }),
                new PdfArray(new[] { alternateSpace.GetColorValue()[0], alternateSpace.GetColorValue()[1], alternateSpace.GetColorValue()[2] }),
                new PdfNumber(1f));
            var pantone = new Separation("PANTONE 485 C", alternateSpace.GetColorSpace(), tintTransform, 1f);
            doc.Add(new Paragraph(text).SetFontColor(pantone).SetFont(font).SetFontSize(12f));
        }
    }
