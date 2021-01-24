    public CuttingSpeed_ViewModel()
    {
        switch (value)
        {
            case "Fast":
                MainColor = new SolidColorBrush(Colors.Pink);
                break;
            case "Slow":
                MainColor = new SolidColorBrush(Colors.Yellow);
                break;
            default:
                MainColor = new SolidColorBrush(Colors.Red);
                break;
        }
    }
    private Brush _MainColor;
    public Brush MainColor
    {
        get { return _MainColor; }
        set { _MainColor = value; OnPropertyChanged("MainColor"); }
    }
