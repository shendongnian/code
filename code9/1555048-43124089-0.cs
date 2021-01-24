    public class Photo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }
        public string FileName { get; set; }
        private string iso = string.Empty;
        public string ISO
        {
            get { return iso; }
            set
            {
                iso = value;
                NotifyPropertyChanged(nameof(ISO));
            }
        }
        private ImageSource image;
        public ImageSource Image
        {
            get { return image; }
            set
            {
                image = value;
                NotifyPropertyChanged(nameof(Image));
            }
        }
        public async Task Load()
        {
            Image = await Task.Run(() =>
            {
                using (var fileStream = new FileStream(
                    FileName, FileMode.Open, FileAccess.Read))
                {
                    return BitmapFrame.Create(
                        fileStream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                }
            });
            ISO = "1600";
        }
    }
