      public class SyncConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter,
                System.Globalization.CultureInfo culture)
            {
                if (targetType != typeof(bool))
                    return ConvertToImageSource("ic_idle"); 
    
                return (bool)value? ConvertToImageSource("ic_success"): ConvertToImageSource("ic_error");
            }
    
            public object ConvertBack(object value, Type targetType, object parameter,
                System.Globalization.CultureInfo culture)
            {
                return (bool)value;
            }
        }
