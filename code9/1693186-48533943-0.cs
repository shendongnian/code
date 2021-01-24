    using System;
    using System.Globalization;
    using System.IO;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    
    class OffscreenRenderer
    {
        public void Render(string sourceImageFilename, string outputImageFilename)
        {
            FontFamily fontFamily = new FontFamily("Arial");
            double fontSize = 42.0;
            Brush foreground = new System.Windows.Media.SolidColorBrush(Color.FromArgb(255, 255, 128, 0));
    
            FormattedText text = new FormattedText("Hello, world!",
                    new CultureInfo("en-us"),
                    FlowDirection.LeftToRight,
                    new Typeface(fontFamily, FontStyles.Normal, FontWeights.Normal, new FontStretch()),
                    fontSize,
                    foreground);
    
            DrawingVisual drawingVisual = new DrawingVisual();
            DrawingContext drawingContext = drawingVisual.RenderOpen();
            var overlayImage = new BitmapImage(new Uri(sourceImageFilename));
            drawingContext.DrawImage(overlayImage,
                                        new Rect(0, 0, overlayImage.Width, overlayImage.Height));
            drawingContext.DrawText(text, new Point(2, 2));
            drawingContext.Close();
    
            RenderTargetBitmap rtb = new RenderTargetBitmap(256, 64, 96, 96, PixelFormats.Pbgra32);
            rtb.Render(drawingVisual);
    
            PngBitmapEncoder png = new PngBitmapEncoder();
            png.Frames.Add(BitmapFrame.Create(rtb));
            using (Stream stream = File.Create(outputImageFilename))
            {
                png.Save(stream);
            }
        }
    }
