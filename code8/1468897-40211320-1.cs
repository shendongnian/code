    public class MyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((string)parameter == "1") ? Visibility.Visible : Visibility.Collapsed;
        }
        // ConvertBack
    }
