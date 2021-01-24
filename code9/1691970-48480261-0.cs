    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var input = value as string;
        if (input.Contains("-"))
        {
            return (Brush)Application.Current.FindResource("MaterialDesignBody");
        }
        return Brushes.White;
    }
