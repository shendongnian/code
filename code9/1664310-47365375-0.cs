    PdfPage pdfPage = yourPDFdoc.AddPage();
    pdfPage.Width = XUnit.FromMillimeter(210);
    pdfPage.Height = XUnit.FromMillimeter(297);
    
    using (XGraphics gfx = XGraphics.FromPdfPage(pdfPage))
    {
        XPen lineRed = new XPen(XColors.Red, 5);
    
        gfx.DrawLine(lineRed, 0, pdfPage.Height / 2, pdfPage.Width, pdfPage.Height / 2);
    }
