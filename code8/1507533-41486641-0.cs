    public string Stuff {
        get { return _Stuff;  }
        private set {
            if (value != _Stuff)
            {
                _Stuff = value;
                Method();
                OnPropertyChanged("Stuff");
            }
        }
    }
