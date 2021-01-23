    class CustomClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        private string _imageLink;
        public string ImageLink
        {
            get
            {
                return _imageLink;
            }
            set
            {
                _imageLink = value;
                RaisePropertyChanged();
            }
        }
        private void RaisePropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
