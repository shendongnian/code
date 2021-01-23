    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            ImageList = new ObservableCollection<ViewModel> { new ViewModel { ImageURI = "ms-appdata:///local/1.png" }, new ViewModel { ImageURI = "ms-appdata:///local/2.png" }, new ViewModel { ImageURI = "ms-appdata:///local/3.png" } };
        }
        public ObservableCollection<ViewModel> ImageList;
        private async void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".jpeg");
            openPicker.FileTypeFilter.Add(".png");
            StorageFile file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                WriteableBitmap Bitmap = new WriteableBitmap(1, 1);
                using (IRandomAccessStream stream = await file.OpenAsync(FileAccessMode.Read))
                {
                    Bitmap.SetSource(stream);
                }
                var clickedItem = e.ClickedItem as ViewModel;
                var FileName = clickedItem.ImageURI.Replace("ms-appdata:///local/", string.Empty);
                await SaveToLocalStorage(FileName, Bitmap);
                clickedItem.NotifyPropertyChanged("ImageURI");
            }
        }
        public static async Task SaveToLocalStorage(string FileName, WriteableBitmap Bitmap)
        {
            StorageFile outputFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(FileName, CreationCollisionOption.ReplaceExisting);
            using (IRandomAccessStream writeStream = await outputFile.OpenAsync(FileAccessMode.ReadWrite))
            {
                byte[] pixels;
                using (Stream stream = Bitmap.PixelBuffer.AsStream())
                {
                    pixels = new byte[(uint)stream.Length];
                    await stream.ReadAsync(pixels, 0, pixels.Length);
                }
                // Encode pixels into stream
                BitmapEncoder encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, writeStream);
                encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Premultiplied, (uint)Bitmap.PixelWidth, (uint)Bitmap.PixelHeight, 96, 96, pixels);
                await encoder.FlushAsync();
            }
        }
    }
    public class ImageURIConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var image = new BitmapImage();
            using (IRandomAccessStream stream = (StorageFile.GetFileFromApplicationUriAsync(new Uri(value.ToString())).AsTask().Result).OpenAsync(FileAccessMode.Read).AsTask().Result)
                image.SetSource(stream);
            return image;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
    public class ViewModel : INotifyPropertyChanged
    {
        private string imageURI;
        public string ImageURI
        {
            get
            {
                return imageURI;
            }
            set
            {
                imageURI = value;
                NotifyPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
