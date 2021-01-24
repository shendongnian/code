    private List<View> _MyChildren;
    public List<View> MyChildren
    {
        get { return _MyChildren; }
        set
        {
            if (_MyChildren != value)
            {
                _MyChildren = value;
                OnPropertyChanged();
            }
        }
    }
