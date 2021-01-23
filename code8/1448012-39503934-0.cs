        public static Image ResizeImage(int newWidth, int newHeight, Image image) {
            int sourceWidth = image.Width;
            int sourceHeight = image.Height;
            //Consider vertical pics
            if (sourceWidth < sourceHeight) {
                int buff = newWidth;
                newWidth = newHeight;
                newHeight = buff;
            }
            int sourceX = 0, sourceY = 0, destX = 0, destY = 0;
            float percent = 0, percentW = 0, percentH = 0;
            percentW = ((float)newWidth / (float)sourceWidth);
            percentH = ((float)newHeight / (float)sourceHeight);
            if (percentH < percentW) {
                percent = percentH;
                destX = System.Convert.ToInt16((newWidth -
                          (sourceWidth * percent)) / 2);
            } else {
                percent = percentW;
                destY = System.Convert.ToInt16((newHeight -
                          (sourceHeight * percent)) / 2);
            }
            int destWidth = (int)(sourceWidth * percent);
            int destHeight = (int)(sourceHeight * percent);
            Bitmap bitmap = new Bitmap(newWidth, newHeight,
                          PixelFormat.Format24bppRgb);
            bitmap.SetResolution(image.HorizontalResolution,
                         image.VerticalResolution);
            Graphics graphic = Graphics.FromImage(bitmap);
            graphic.Clear(Color.Black);
            graphic.InterpolationMode =
                System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            graphic.DrawImage(image,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);
            graphic.Dispose();
            image.Dispose();
            return bitmap;
        }
            
