    var rect = new Rectangle { Fill = linGrBrush };
    var size = new Size(1000, 1);
    rect.Measure(size);
    rect.Arrange(new Rect(size));
    var bmp = new RenderTargetBitmap(1000, 1, 96, 96, PixelFormats.Pbgra32);
    bmp.Render(rect);
