    public class InvertedVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return InvertedVisibility(value);
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return InvertedVisibility(value);
        }
        private object InvertedVisibility(object value)
        {
            var visibility = value?.ToString();
            if (string.IsNullOrEmpty(visibility) || visibility.Equals("Visible"))
            {
                return Visibility.Collapsed;
            }
            else
            {
                return Visibility.Visible;
            }
        }
    }
