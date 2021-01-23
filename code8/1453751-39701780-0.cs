    public static class ImageExtensions {
    
        public static System.Drawing.Image Reduce(this System.Drawing.Image sourceImage, double size) {
          var percent = size / 100;
          var width = (int)(sourceImage.Width * percent);
          var height = (int)(sourceImage.Height * percent);
          var destX = width / 2;
          var destY = height/2;
          Bitmap targetBmp;
          using (var newBmp = new Bitmap(sourceImage))
            targetBmp = newBmp.Clone(new Rectangle(destX, destY, width, height), sourceImage.PixelFormat);
          return targetBmp;
        }
    
      }
