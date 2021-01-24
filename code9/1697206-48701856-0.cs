    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private BitmapImage routeImage;
        public BitmapImage RouteImage
        {
            get { return routeImage; }
            set
            {
                routeImage = value;
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(RouteImage)));
            }
        }
        public void LoadImage(string archiveName, string entryName)
        {
            using (var archive = ZipFile.OpenRead(archiveName))
            {
                var entry = archive.GetEntry(entryName);
                if (entry != null)
                {
                    using (var zipStream = entry.Open())
                    using (var memoryStream = new MemoryStream())
                    {
                        zipStream.CopyTo(memoryStream);
                        memoryStream.Position = 0;
                        var bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.CacheOption = BitmapCacheOption.OnLoad;
                        bitmap.StreamSource = memoryStream;
                        bitmap.EndInit();
                        RouteImage = bitmap;
                    }
                }
            }
        }
    }
