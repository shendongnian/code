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
            var target = new BitmapImage();
            using (var stream = new MemoryStream())
            {
                encoder.Save(stream);
                stream.Position = 0;
                target.BeginInit();
                target.DecodePixelWidth = 283;
                target.CacheOption = BitmapCacheOption.OnLoad;
                target.StreamSource = stream;
                target.EndInit();
            }
            target.Freeze();
            return target;
        }
    }
