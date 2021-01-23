    string _test;
    public string Test
    {
        get { return _test; }
        set
        {
            _test = value;
            OnPropertyChanged(); // will pass "Test" as propertyName
        }
    }
    protected void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
