    public static Image ImageResize(Image img, int width, int height)
    {
        var tgtRect = new Rectangle(0, 0, width, height);
        var tgtImg = new Bitmap(width, height);
        tgtImg.SetResolution(img.HorizontalResolution, img.VerticalResolution);
        using (var graphics = Graphics.FromImage(tgtImg))
        {
            graphics.CompositingMode = CompositingMode.SourceCopy;
            using (var wrapMode = new ImageAttributes())
            {
                wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                graphics.DrawImage(img, tgtRect, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, wrapMode);
            }
            return tgtImg;
        }
    }
