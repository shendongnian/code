    public class ColorIndexToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            if (!(value is DrawingColor))
                return null;
            if (((DrawingColor)value).Index == -1 || ((DrawingColor)value).Index == -10)
                return Color.FromArgb(0, 255, 255, 255);
            else
                return Color.FromArgb(255, ((DrawingColor)value).R, ((DrawingColor)value).G, ((DrawingColor)value).B);
        }
    
        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            return value.Equals(true) ? parameter : Binding.DoNothing;
        }
    }
