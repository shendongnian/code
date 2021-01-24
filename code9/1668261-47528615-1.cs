    public class RatioToGradientConverter : IValueConverter
    {
        public Color Color1 { get; set; }
        public Color Color2 { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double ratio = 0;
            if (value is double)
                ratio = (double) value;
            return GradientGenerator.GenerateTwoColorBrush(Color1, Color2, ratio);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
