    private SolidColorBrush _backgroundColor;
    public SolidColorBrush BackColor {
      get { return _backgroundColor; }
      set { this.OnPropertyChanged(nameof(BackColor)); }
    }
