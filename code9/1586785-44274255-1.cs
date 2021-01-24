    public class StringToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
    
            if (value.ToString() == "old")
            {
                var color = (Color)ColorConverter.ConvertFromString("Red");
                return color;
            }
            else if (value.ToString() == "Upcoming")
            {
                var color = (Color)ColorConverter.ConvertFromString("Green");
                return color;
            }
    
    
            return (Color)ColorConverter.ConvertFromString("Black");
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
