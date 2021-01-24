    public class SliderValueMultiplier : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null) return 0;
            double.TryParse(parameter.ToString(), out double multiplier);
            return value != null ? Math.Round((double) value, 2) * multiplier : 0;        
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
