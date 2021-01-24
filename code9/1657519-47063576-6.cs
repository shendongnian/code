    public class YourConverter : IValueConverter
    {
        public Brush FirstBrush { get; set; }
        public Brush SecondBrush { get; set; }
        public object Convert(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            double val = (double)value;
            if (val >= 1)
            {
                return FirstBrush;
            }
            if (val >= 0.5)
            {
                return SecondBrush;
            }
            return Brushes.Transparent;
        }
        public object ConvertBack(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
