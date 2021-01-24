    private SolidColorBrush backColor;
    public SolidColorBrush BackColor
    {
        get { return backColor; }
        set
        {
            backColor = value;
            OnPropertyChanged(nameof(BackColor));
        }
    }
