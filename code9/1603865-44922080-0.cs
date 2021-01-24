    public class ReadonlyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var content = ((ComboBoxItem)value).Content;
            var isEnabled = content.Equals("yes");
    
            return isEnabled;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
