    public class DataConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var tmp = (int[])value;
            var convert = new Dictionary<StopBits, string>()
            {
                {StopBits.None, "none"},
                {StopBits.One, "1 bit"},
                {StopBits.Two, "2 bit"},
                {StopBits.OnePointFive, "1.5 bit"}
            };
            return convert;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
