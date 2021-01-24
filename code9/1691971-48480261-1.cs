    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value.ToString().Contains("-"))
        {
            return (Brush)Application.Current.FindResource("MaterialDesignBody");
        }
        return Brushes.White;
    }
