    public string SettingProperty
    {
        get { return _setting; }
        set
        {
            if(_setting != value) // Or String.Equals(_setting, value, ...)
            {
                 _setting = value;
                 OnPropertyChanged(); // Invoke using no argument.
            }
        }
    }
    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
