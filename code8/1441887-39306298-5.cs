    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        bool isVisible = (bool)value;
        return (isVisible ? Visibility.Visible : Visibility.Collapsed);
    }
  
