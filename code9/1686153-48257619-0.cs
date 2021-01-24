    public class ImageSourceConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value != null)
                {
                    string code = value as string;
                    if (!string.IsNullOrEmpty(code))
                        return string.Format("/pathof the image/{0}.png", code);
                }
                return value;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return value;
            }
        }
