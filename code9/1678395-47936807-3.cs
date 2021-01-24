    public class ForeGroundColorConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, 
                System.Globalization.CultureInfo culture)
        {
            var color = (string)value;
            
            if(color.IndexOf("good", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                // return 'Good' color.
            }
            else if (color.IndexOf("kind", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                // return 'Kind' color.
            }
            // More cases.
        }
        public object ConvertBack(object value, Type targetType, object parameter, 
                System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
