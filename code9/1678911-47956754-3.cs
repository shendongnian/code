    namespace MyUWPApplication.Converter
    {
        class BooleanToVisibilityConverter : IValueConverter
        {
            public BooleanToVisibilityConverter()
            {
            }
    
            public object Convert(object value, Type targetType, object parameter, string language)
            {
                if (value is bool && (bool)value)
                {
                    return Visibility.Visible;
                }
                return Visibility.Collapsed;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, string language)
            {
                throw new NotImplementedException();
            }
        }
    }
