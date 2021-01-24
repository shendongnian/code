    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        BooleanObject boolobject = (BooleanObject)value;
        if (boolobject.IsBoolValueOne)
            return System.Windows.Media.Brushes.Green;
        else if (boolobject.IsBoolValueTwo)
            return System.Windows.Media.Brushes.Red;
        else if (boolobject.IsBoolValueThree)
            return (SolidColorBrush)(new BrushConverter().ConvertFrom("#d3d300"));
        return System.Windows.Media.Brushes.Black;
    }
