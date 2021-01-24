    public bool saveTheChartToFile(ChartBase view)
    {
        Size size = new Size(100, 100);
        RenderTargetBitmap result = new RenderTargetBitmap((int)size.Width, (int)size.Height, 96, 96, PixelFormats.Pbgra32);
        view.Measure(size);
        view.Arrange(new Rect(size));
        result.Render(view);
        BitmapEncoder encoder = new JpegBitmapEncoder();
        encoder.Frames.Add(BitmapFrame.Create(result));
        using (Stream stm = File.Create("test.jpg"))
        {
            encoder.Save(stm);
        }
        return true;
    }
