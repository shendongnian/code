    WorkingBMP = new RenderTargetBitmap(BOARD_WIDTH, BOARD_HEIGHT, 96, 96, PixelFormats.Pbgra32);
    TreeFile = "pack://application:,,,/Images/" + TreeFile;
    var image = new Image
    {
        Source = new BitmapImage(new Uri(TreeFile))
    };
    image.Width = 10;
    image.Height = 10;
    Canvas.SetLeft(image, x );
    Canvas.SetTop(image, y );
    DrawingVisual drawingVisual = new DrawingVisual();
    DrawingContext drawingContext = drawingVisual.RenderOpen();
    drawingContext.DrawImage(new BitmapImage(new Uri(TreeFile)), new Rect(x, y, image.Width, image.Height));
    drawingContext.Close();
    WorkingBMP.Render(drawingVisual);
    MainCanvas.Children.Add(image);
