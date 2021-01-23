    public class PicturesViewModel
    {
        public ObservableCollection<BitmapImage> myImages { get; set; }
        public async Task<PicturesViewModel> GetImages()
        {
            myImages = new ObservableCollection<BitmapImage>();
            var files = await KnownFolders.PicturesLibrary.GetFilesAsync();
            foreach (var file in files)
            {
                using (var stream = await file.OpenReadAsync())
                {
                    BitmapImage image = new BitmapImage();
                    await image.SetSourceAsync(stream);
                    myImages.Add(image);
                }
            }
            return this;
        }
    }
