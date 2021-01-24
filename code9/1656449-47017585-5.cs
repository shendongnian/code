    public class EvaluateTextBox : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                return Helpers.Calculate(value);
            }
            catch
            {
                return value;
            }
        }
    }
