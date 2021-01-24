    public event PropertyChangedEventHandler PropertyChanged;
    private string _myProperty;
    public string MyProperty
    {
        get { return _myProperty; }
        set
        {
            _myProperty = value;
            OnPropertyChanged();
        }
    }
    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
