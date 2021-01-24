            private string _Name;
            public string Name { get { return _Name; } set { _Name = value;
    OnPropertyChanged(); } }
            private string _Description;
            public string Description { get{ return _Description; }set{ _Description = value; OnPropertyChanged(); } }
        }
    
    public event PropertyChangedEventHandler PropertyChanged;
    
    public void OnPropertyChanged([CallerMemberName]string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
