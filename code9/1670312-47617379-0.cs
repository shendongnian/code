    public class ViewModel
    {
        public ObservableCollection<ImageSource> Images { get; }
            = new ObservableCollection<ImageSource>();
        public async Task LoadFolder(string folderName, string extension = "*.jpg")
        {
            Images.Clear();
            foreach (var path in Directory.EnumerateFiles(folderName, extension))
            {
                Images.Add(await LoadImage(path));
            }
        }
        public Task<BitmapImage> LoadImage(string path)
        {
            return Task.Run(() =>
            {
                var bitmap = new BitmapImage();
                using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    bitmap.BeginInit();
                    bitmap.DecodePixelHeight = 100;
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.StreamSource = stream;
                    bitmap.EndInit();
                    bitmap.Freeze();
                }
                return bitmap;
            });
        }
    }
