    public static class ImageExtensions {
    
        public static System.Drawing.Image Reduce(this System.Drawing.Image sourceImage, double size) {
          var percent = size / 100;
          var width = (int)(sourceImage.Width * percent);
          var height = (int)(sourceImage.Height * percent);         
          Bitmap targetBmp;
          using (var newBmp = new Bitmap(sourceImage, width, height))
            targetBmp = newBmp.Clone(new Rectangle(0, 0, width, height), sourceImage.PixelFormat);
          return targetBmp;
        }
    
      }
