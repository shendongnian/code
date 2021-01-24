    public bool saveTheChartToFile(ChartBase view)
    {
        Size size = new Size(view.ActualWidth, view.ActualHeight);
        if (size.IsEmpty)
            return false;
        view.Measure(size);
        view.Arrange(new Rect(new Point(0, 0), view.DesiredSize));
        RenderTargetBitmap result = new RenderTargetBitmap((int)size.Width, (int)size.Height, 96, 96, PixelFormats.Pbgra32);
        ...
    }
