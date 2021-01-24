        public static BitmapSource ControlToBitmap(CustomControl control)
        {
            int W = (int)control.ActualWidth;
            int H = (int)control.ActualHeight;
            RenderTargetBitmap renderBitmap = new RenderTargetBitmap(
             W, H,
             96d, 96d, PixelFormats.Pbgra32);
            // needed otherwise the image output is black
            control.Measure(new System.Windows.Size(W, H));
            control.Arrange(new Rect(new System.Windows.Size(W, H)));
            renderBitmap.Render(control);
            var BS = RenderTargetBitmapToBitmap(renderBitmap);
            return BS;
        }
