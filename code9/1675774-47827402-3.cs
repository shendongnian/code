    public class YourViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string imageSource;
        public string ImageSource
        {
            get { return imageSource; }
            set
            {
                imageSource = value;
                RaisePropertyChanged(nameof(ImageSource));
            }
        }
    }
