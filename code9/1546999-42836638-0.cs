    private static void AddImage(XGraphics gfx, PdfPage page, string imagePath, int xPosition, int yPosition)
        {
            if (!File.Exists(imagePath))
            {
                throw new FileNotFoundException(String.Format("Could not find image {0}.", imagePath));
            }
            XRect rec = gfx.Transformer.WorldToDefaultPage(new XRect(new XPoint(xPosition, yPosition), new XSize(page.Width, page.Height)));
            PdfRectangle rect = new PdfRectangle(rec);
            page.AddWebLink(rect, "http://www.google.com");
            XImage xImage = XImage.FromFile(imagePath);
            page.Width = xImage.PixelWidth;
            page.Height = xImage.PixelHeight;
            gfx.DrawImage(xImage, xPosition, yPosition, xImage.PixelWidth, xImage.PixelHeight);
        }
