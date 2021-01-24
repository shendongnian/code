    private string _imageSource;
        public string ImageSource
        {
            get { return _imageSource; }
            set { _imageSource = value;
                RaisePropertyChanged("ImageSource");  //INotifyPropertyChanged
            }
        }
