     public class StringToColorConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (((KeyValuePair<int, string>)value).Value.ToString() == "Agriculture")
                    return Brushes.Green;
                //and so on or other ways to get the color
                return Brushes.Transparent;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
