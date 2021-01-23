    private MyBar _bar;
    public MyBar Bar
    {
        get
        {
            return _bar;
        }
        set
        {
            if (_bar != value)
            {
                _bar = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Bar)));
            }
        }
    }
