    public class ThumbnailCreator
    {
        public static BitmapImage CreateThumbnail(string imagePath)
        {
            BitmapFrame source;
            using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
            {
                source = BitmapFrame.Create(
                    stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            }
            var encoder = new JpegBitmapEncoder() { QualityLevel = 17 };
            encoder.Frames.Add(BitmapFrame.Create(source));
            var bitmap = new BitmapImage();
            using (var stream = new MemoryStream())
            {
                encoder.Save(stream);
                stream.Position = 0;
                bitmap.BeginInit();
                bitmap.DecodePixelWidth = 283;
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.StreamSource = stream;
                bitmap.EndInit();
            }
            bitmap.Freeze();
            return bitmap;
        }
