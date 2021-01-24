    public class TestColorConverter : IValueConverter
    {
        // the question doesn't explain the status type, so I use string.
        // probably replace string with your actual status type
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (string.Equals("Check", parameter as string))
            {
                return HasColor(value as string);
            }
            return GetColor(value as string);
        }
        private bool HasColor(string status)
        {
            return GetColor(status) != null;
        }
        private Brush GetColor(string status)
        {
            if (string.IsNullOrWhiteSpace(status))
            {
                return null;
            }
            if (status.StartsWith("a"))
            {
                return Brushes.Red;
            }
            return Brushes.DarkGoldenrod;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
