    ...
    public static Dictionary<string, System.Drawing.Image> ExtractImages(string filename)
    {
        var images = new Dictionary<string, System.Drawing.Image>();
        using (var reader = new PdfReader(filename))
        {
            var parser = new PdfReaderContentParser(reader);
            ImageRenderListener listener = null;
            for (var i = 1; i <= reader.NumberOfPages; i++)
            {
                // v-- Determine clockwise rotation of page
                Console.WriteLine("Page {1} is rotated by {0}°.\n", reader.GetPageRotation(i), i);
                // ^-- Determine clockwise rotation of page
                parser.ProcessContent(i, (listener = new ImageRenderListener()));
                var index = 1;
                [...]
            }
            return images;
        }
    }
    ...
    public void RenderImage(ImageRenderInfo renderInfo)
    {
        // v-- Determine transformation matrix of image
        Matrix ctm = renderInfo.GetImageCTM();
        Console.WriteLine("Found image with transformation matrix:\n{0}\n", ctm);
        // ^-- Determine transformation matrix of image
        PdfImageObject image = renderInfo.GetImage();
        PdfName filter = (PdfName)image.Get(PdfName.FILTER);
        [...]
    }
    ...
