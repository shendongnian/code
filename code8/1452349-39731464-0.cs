    public class CaptureEventArgs : EventArgs
    {
        public BitmapImage BitmapImage
        {
            get;
            private set;
        }
        public CaptureEventArgs(Bitmap bitmap)
        {
            using (var memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage = new BitmapImage();
                BitmapImage.BeginInit();
                BitmapImage.StreamSource = memory;
                BitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                BitmapImage.EndInit();
                BitmapImage.Freeze();
            }
        }
    }
