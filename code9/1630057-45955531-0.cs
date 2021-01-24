    public class RangeConverter : IValueConverter
    {
        public double Min { get; set; }
        public double Max { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var d = System.Convert.ToDouble(value, culture);
            return Math.Max(Min, Math.Min(Max, d));
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
