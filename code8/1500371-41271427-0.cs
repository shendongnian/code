    public static SoftwareBitmap Resize(this SoftwareBitmap softwareBitmap, float newWidth, float newHeight)
    {
        using (var resourceCreator = CanvasDevice.GetSharedDevice())
        using (var canvasBitmap = CanvasBitmap.CreateFromSoftwareBitmap(resourceCreator, softwareBitmap))
        using (var canvasRenderTarget = new CanvasRenderTarget(resourceCreator, newWidth, newHeight, canvasBitmap.Dpi))
        using (var drawingSession = canvasRenderTarget.CreateDrawingSession())
        using (var scaleEffect = new ScaleEffect())
        {
            scaleEffect.Source = canvasBitmap;
            scaleEffect.Scale = new System.Numerics.Vector2(newWidth / softwareBitmap.PixelWidth, newHeight / softwareBitmap.PixelHeight);
            drawingSession.DrawImage(scaleEffect);
            drawingSession.Flush();
            return SoftwareBitmap.CreateCopyFromBuffer(canvasRenderTarget.GetPixelBytes().AsBuffer(), BitmapPixelFormat.Bgra8, (int)newWidth, (int)newHeight, BitmapAlphaMode.Premultiplied);
        }
    }
