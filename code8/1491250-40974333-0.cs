    public class MetersToFeetConverter : IValueConverter
    {
        /// <summary>
        /// Converts meters to feet.
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            value = (double)value * 3.2808;
            return (value.ToString() + " F"); 
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
