    private byte[] ConvertInkCanvasToByteArray()
    {
        var rect = new Rect(icSignature.RenderSize);
        var visual = new DrawingVisual();
        using (var dc = visual.RenderOpen())
        {
            dc.DrawRectangle(new VisualBrush(icSignature), null, rect);
        }
        var rtb = new RenderTargetBitmap(
            (int)rect.Width, (int)rect.Height, 96d, 96d, PixelFormats.Default);
        rtb.Render(visual);
        var encoder = new PngBitmapEncoder();
        encoder.Frames.Add(BitmapFrame.Create(rtb));
        using (var stream = new MemoryStream())
        {
            encoder.Save(stream);
            return stream.ToArray();
        }
    }
