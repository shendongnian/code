    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value.ToString() == "x")
        {
            return new SolidColorBrush(Colors.Red);
        }
        return new SolidColorBrush(Colors.Transparent);
    }
    
    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        return value;
    }
