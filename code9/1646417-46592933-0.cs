    public static BitmapSource CreateBitmapFromVisual(Visual target, Double dpiX, Double dpiY)
        {
            if (target == null)
            {
                return null;
            }
     
            Rect bounds = VisualTreeHelper.GetContentBounds(target);
     
            RenderTargetBitmap rtb = new RenderTargetBitmap((Int32)(bounds.Width * dpiX / 96.0),
                                                                                               (Int32)(bounds.Height * dpiY / 96.0),
                                                                                               dpiX,
                                                                                               dpiY,
                                                                                               PixelFormats.Pbgra32);
     
            DrawingVisual dv = new DrawingVisual();
            using (DrawingContext dc = dv.RenderOpen())
            {
                VisualBrush vb = new VisualBrush(target);
                dc.DrawRectangle(vb, null, new Rect(new Point(), bounds.Size));
            }
     
            rtb.Render(dv);
     
            return rtb;
        }
