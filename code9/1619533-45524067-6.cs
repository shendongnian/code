    public class ColorConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var status = (bool?) value;
            if (status == null) return Color.Black;                
            return status.Value ? Color.Green : Color.Red;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
