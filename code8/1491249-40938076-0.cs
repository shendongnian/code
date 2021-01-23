    // This is set by the command.
    private bool _isMeters = true;
    
    private double _Alt;
    public double Alt
    {
        get { return _Alt; }
        set { _Alt = value; OnPropertyChanged("Alt"); OnPropertyChanged("AltInCurrentUnit"); }
    }
    // Rename the suffix as you wish.
    public string AltInCurrentUnit => GetInCurrentUnit(_Alt);
    
    // This method is used by all "InCurrentUnit"-properties.
    private string GetInCurrentUnit(double meters) =>
        // If you don't like expression bodied methods or ternaries then reformat as you wish.
        _isMeters ?
            $"{meters:F1} M" :
            $"{(meters * 3.2808):F1} F";
