    [ValueConversion(typeof(bool?), typeof(Cursor))]
    public class BooleanToCursorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((bool?)value == true)
            {
                return Cursors.Cross;
            }
            else
            {
                return Cursors.Arrow;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
