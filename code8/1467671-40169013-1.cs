    public class BoolToVisConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool)) throw new ArgumentException("bool value expected");
            Visibility invisibleMode = (parameter == null || !(parameter is string) ||
                                        !((string) parameter).ToLower().Contains("hidden"))
                                           ? Visibility.Collapsed
                                           : Visibility.Hidden;
            if ((parameter as string)?.ToLower().Contains("invert") ?? false) return (!(bool) value) ? Visibility.Visible : invisibleMode;
            return ((bool) value) ? Visibility.Visible : invisibleMode;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
