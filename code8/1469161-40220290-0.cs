    [ValueConversion(typeof(int), typeof(Brush))]
    public class NumberToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int val = (int)value;
            if (val < 50)
                return Brushes.Red;
            if (val > 60)
                return Brushes.Green;
            return Brushes.Transparent;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
