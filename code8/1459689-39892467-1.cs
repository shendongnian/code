    public System.Windows.Media.Brush ForegroundColor
    {
        get { return _foregroundColor; }
        set
        {
            _foregroundColor = value;
            OnPropertyChanged("ForegroundColor");
        }
    }
