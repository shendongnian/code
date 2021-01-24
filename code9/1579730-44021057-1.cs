    public class ImageItem
    {
        private string url;
        public ImageItem(string url)
        {
            this.url = url;
        }
        public ImageSource Image
        {
            get
            {
                var image = new BitmapImage();
                var buffer = new WebClient().DownloadData(url);
                using (var stream = new MemoryStream(buffer))
                {
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.StreamSource = stream;
                    image.EndInit();
                }
                image.Freeze();
                return image;
            }
        }
    }
