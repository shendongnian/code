    public class ImageClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int imageWidth;
        public int ImageWidth
        {
            get { return imageWidth; }
            set
            {
                imageWidth = value;
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(ImageWidth)));
            }
        }
        ...
    }
