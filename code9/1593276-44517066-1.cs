    public CuttingSpeed_ViewModel()
    {
        switch (value)
        {
            case "Fast":
                MainColor = Brushes.Pink;
                break;
            case "Slow":
                MainColor = Brushes.Yellow;
                break;
            default:
                MainColor = Brushes.Red;
                break;
        }
    }
    private Brush _MainColor;
    public Brush MainColor
    {
        get { return _MainColor; }
        set { _MainColor = value; OnPropertyChanged("MainColor"); }
    }
