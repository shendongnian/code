    using iText.Kernel.Colors;
    using iText.Kernel.Pdf.Function;
    using iText.Kernel.Pdf;
    private Separation SpotColor(string name, int r,int g,int b)
    {
        var alternateSpace = new DeviceRgb(r, g, b);
        var tintTransform = new PdfFunction.Type2(
            new PdfArray(new[] { 0.0f, 1f }),
            null,
            new PdfArray(new[] { 1f, 1f, 1f }),
            new PdfArray(new[] { alternateSpace.GetColorValue()[0], alternateSpace.GetColorValue()[1], alternateSpace.GetColorValue()[2]}),
            new PdfNumber(1f));
    
        var spot = new Separation(name, alternateSpace.GetColorSpace(), tintTransform, 1f);
        return spot;
    }
