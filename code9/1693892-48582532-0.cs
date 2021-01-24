    public class TooltipObject : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value != null)
                {
                    return ((TextBlock)value).Text;
                }
    
                return value;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return value;
            }
        }
