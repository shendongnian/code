    public class ThumbnailCreator
    {
        public static BitmapImage CreateThumbnail(string imagePath)
        {
            var bitmap = new BitmapImage();
            using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
            {
                bitmap.BeginInit();
                bitmap.DecodePixelWidth = 283;
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.StreamSource = stream;
                bitmap.EndInit();
            }
            bitmap.Freeze();
            return bitmap;
        }
    }
