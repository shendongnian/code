        get { return _stringProperty; }
        set
        {
            if (!ReferenceEquals(_stringProperty, value))
            {
                _stringProperty = value;
                OnPropertyChanged("stringProperty");  
            }
        }
    }
