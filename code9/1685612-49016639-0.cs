    public static Byte[] HtmlToPdf()
    {
    var Renderer = new IronPdf.HtmlToPdf();
    var PDF = Renderer.RenderHtmlAsPdf("<p>Any TEXT</p>" );
    return PDF.Stream.ToArray();
    }
