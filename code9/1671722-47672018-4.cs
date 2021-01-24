    public class MyConverter : IMultiValueConverter
    {
        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value[0] is double && value[1] is double)
            {
                return ((double)value[0] < (double)value[1]) ? Visibility.Visible : Visibility.Collapsed;
            }
            return Visibility.Collapsed;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
