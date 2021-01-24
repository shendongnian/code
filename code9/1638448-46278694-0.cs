    public class IsNotNullConverter : IValueConverter
    {
        public IValueConverter InnerConverter { get; set; }
        public object Convert(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            if (InnerConverter != null)
                value = InnerConverter.Convert(value, targetType, parameter, culture);
            return value != null &&
                   value != DependencyProperty.UnsetValue;
        }
        public object ConvertBack(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
