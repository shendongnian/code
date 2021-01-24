    public class YourConverter : IValueConverter
    {
        public Brush PrimaryHueMidBrush { get; set; }
        public object Convert(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            double val = (double)value;
            if (val >= 1)
            {
                return PrimaryHueMidBrush;
            }
            if (val >= 0.5)
            {
                return Brushes.MediumVioletRed;
            }
            return Brushes.Transparent;
        }
        public object ConvertBack(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
