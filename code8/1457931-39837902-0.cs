            Rect rect = new Rect();
            rect.Width = Width - BorderSize;
            rect.Height = Height - BorderSize;
            DrawingVisual drawingVisual = new DrawingVisual();
            using (var draw = drawingVisual.RenderOpen())
            {
                DrawRoundedRectangle(draw, new SolidColorBrush(Color.FromRgb(0, 0, 0)),
                new Pen(new SolidColorBrush(Color.FromRgb(0, 0, 0)), BorderSize), rect, new CornerRadius(5, 5, 5, 5));
            }
            RenderTargetBitmap rtb = new RenderTargetBitmap(rect.Width, rect.Height, 96, 96, PixelFormats.Default);
            rtb.Render(drawingVisual);
            Image image = new Image();
            image.Source = rtb;
            previewcanvas.Children.Add(image);
