    public static DependencyProperty PinCommandProperty = DependencyProperty.Register("PinCommand", typeof(RelayCommand), typeof(TileToolbar), new PropertyMetadata(null));
    
    public RelayCommand PinCommand
    {
        get
        {
            return (RelayCommand)GetValue(PinCommandProperty);
        }
        set
        {
            SetValue(PinCommandProperty, value);
        }
    }
