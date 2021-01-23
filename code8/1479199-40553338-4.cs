    public class BoolToFontWeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is bool)
            {
                return ((bool)value) ? FontWeights.ExtraBold : FontWeights.Normal;
            }
            else
            {
                return DependencyProperty.UnsetValue;
            }
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotSupportedException();
        }
    }
