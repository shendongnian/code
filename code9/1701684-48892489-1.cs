    public class ViewModel
    {
        public ObservableCollection<ImageSource> Images { get; }
            = new ObservableCollection<ImageSource>();
        public async Task LoadImagesAsync(IEnumerable<string> filenames)
        {
            foreach (var filename in filenames)
            {
                Images.Add(await Task.Run(() => LoadImage(filename)));
            }
        }
        public ImageSource LoadImage(string filename)
        {
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.DecodePixelWidth = 200;
            bitmap.UriSource = new Uri(filename);
            bitmap.EndInit();
            bitmap.Freeze();
            return bitmap;
        }
    }
