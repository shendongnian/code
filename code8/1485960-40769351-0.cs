    private SolidColorBrush _backgroundColor = new SolidColorBrush(Colors.Yellow);
    public SolidColorBrush BackgroundColor
    {
        get { return _backgroundColor; }
        set
        {
            _backgroundColor= value;
            OnPropertyChanged();
        }
    }
