    public class ImageData
    {
        public string Name { get; set; }
        public ImageSource ImageSource { get; set; }
    }
    public class ViewModel
    {
        public ObservableCollection<ImageData> Images { get; }
            = new ObservableCollection<ImageData>();
        public async Task LoadFolder(string folderName, string extension = "*.jpg")
        {
            Images.Clear();
            foreach (var path in Directory.EnumerateFiles(folderName, extension))
            {
                Images.Add(new ImageData
                {
                    Name = Path.GetFileName(path),
                    ImageSource = await LoadImage(path)
                });
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
