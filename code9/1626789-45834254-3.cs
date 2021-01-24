    public class BooleanToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = System.Convert.ToBoolean(value, CultureInfo.InvariantCulture);
            return val ? "Vrai" : "Faux";
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string temp = value.ToString();
            return temp.ToLower().Equals("vrai") ? true : false;
        }
    }
