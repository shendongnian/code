        public string Category
        {
            get
            {
                return _category;
            }
            set
            {
                if (_category != value)
                {
                    _category = value;
                    RaisePropertyChanged("Category");
                    RaisePropertyChanged("CategoryLocation");
                }
            }
        }
        public string Location
        {
            get
            {
                return _location;
            }
            set
            {
                if (_location != value)
                {
                    _location = value;
                    RaisePropertyChanged("Location");
                    RaisePropertyChanged("CategoryLocation");
                }
            }
        }
