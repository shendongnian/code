    public class GroupConverter : IValueConverter
    {
        int n;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return n++ == 0 ? Brushes.Yellow  : Brushes.Transparent;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
