            System.Windows.Controls.Image img = new System.Windows.Controls.Image();
            img.Source = new BitmapImage(new System.Uri(System.Environment.CurrentDirectory + "/" + filename, System.UriKind.RelativeOrAbsolute));
 
            TransformGroup tg = new TransformGroup();
            double scaleX = (double)w / (double)img.Source.Width;
            double scaleY = (double)h / (double)img.Source.Height;
            tg.Children.Add(new ScaleTransform(scaleX, scaleY));
            tg.Children.Add(new RotateTransform(b.Rotation, w/2, h/2));
            tg.Children.Add(new TranslateTransform(x, y));
            img.RenderTransform = tg;
            canvas.Children.Add(img);
    
            double dpi = 96d;
            RenderTargetBitmap rtb = new RenderTargetBitmap(1700, 1200, dpi, dpi, System.Windows.Media.PixelFormats.Default);
            canvas.UpdateLayout();
    
            rtb.Render(canvas);
    
            BitmapEncoder pngEncoder = new PngBitmapEncoder();
            pngEncoder.Frames.Add(BitmapFrame.Create(rtb));
            using (var fs = System.IO.File.OpenWrite("test.png"))
            {
                pngEncoder.Save(fs);
            }
