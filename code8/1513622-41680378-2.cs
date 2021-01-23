    public class DataToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Visibility dataVisible = (value.ToString().Length == 0) ? Visibility.Visible : Visibility.Collapsed;
            return dataVisible;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
