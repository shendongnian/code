    public class Page : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private BitmapSource image;
        public BitmapSource Image
        {
            get { return image; }
            set
            {
                image = value;
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(Image)));
            }
        }
    }
