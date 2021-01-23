    public int Size
    {
        get { return _Size; }
        set
        {
            if (_Size != value)
            {
                _Size = value;
                NotifyPropertyChanged();
            }
        }
    }
    private int _Size;
