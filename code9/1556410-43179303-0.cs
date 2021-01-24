        private Icon DrawIcon(Brush brush)
        {
            //http://stackoverflow.com/questions/6311545/c-sharp-write-text-on-bitmap     
            Bitmap bmp = new Bitmap(MyNameSpace.Properties.Resources.desktop_windows_48px);
            
            // Create a rectangle for the entire bitmap
            RectangleF rectf = new RectangleF(0, 0, bmp.Width, bmp.Height);
            // Create graphic object that will draw onto the bitmap
            Graphics g = Graphics.FromImage(bmp);
            // The smoothing mode specifies whether lines, curves, and the edges of filled areas use smoothing (also called antialiasing). One exception is that path gradient brushes do not obey the smoothing mode. Areas filled using a PathGradientBrush are rendered the same way (aliased) regardless of the SmoothingMode property.
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            // The interpolation mode determines how intermediate values between two endpoints are calculated.
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            // Use this property to specify either higher quality, slower rendering, or lower quality, faster rendering of the contents of this Graphics object.
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            // This one is important
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                       
            // Draw the text onto the image
            g.FillRectangle(brush, new Rectangle(2, 4, 20, 12));
            // Flush all graphics changes to the bitmap
            g.Flush();
            Bitmap temp = bmp;
            // Get an Hicon for myBitmap.
            IntPtr Hicon = temp.GetHicon();
            // Create a new icon from the handle.
            Icon newIcon = Icon.FromHandle(Hicon);
            return newIcon;            
        }
