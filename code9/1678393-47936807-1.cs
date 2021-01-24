    public class ForeGroundColorConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, 
                System.Globalization.CultureInfo culture)
        {
            var color = (string)value;
            
            if(color == "Good") 
            {
                // return 'Good' color.
            }
            else if (color == "Kind")
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
