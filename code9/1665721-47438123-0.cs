    private void SaveImage(FrameworkElement targetElement, string savePath)
    {
        var bmp = new RenderTargetBitmap((int)targetElement.ActualWidth, (int)targetElement.ActualHeight, 96, 96, PixelFormats.Default);
        bmp.Render(targetElement);
        using (var stream = new MemoryStream())
        {
            var encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bmp));
            encoder.QualityLevel = 100;
            encoder.Save(stream);
            File.WriteAllBytes(savePath, stream.ToArray());
        }
    }
