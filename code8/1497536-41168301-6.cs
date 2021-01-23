    public class PicturesViewModel
    {
        public ObservableCollection<BitmapImage> MyImages { get; set; }
        public async Task GetImages()
        {
            MyImages = new ObservableCollection<BitmapImage>();
            var files = await KnownFolders.PicturesLibrary.GetFilesAsync();
            foreach (var file in files)
            {
                using (var stream = await file.OpenReadAsync())
                {
                    BitmapImage image = new BitmapImage();
                    await image.SetSourceAsync(stream);
                    MyImages.Add(image);
                }
            }
        }
    }
