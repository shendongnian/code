    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ImageModel> Images { get; }
            = new ObservableCollection<ImageModel>();
        private ImageModel currentImage;
        public ImageModel CurrentImage
        {
            get { return currentImage; }
            set
            {
                currentImage = value;
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(CurrentImage)));
            }
        }
        ...
    }
