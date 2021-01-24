    public class EnumIntegerConverter : IValueConverter
    {
        // probably add some code to ensure the enum type is actually set
        // or move it to the converter parameter in order to use the same converter instance with different types
        public Type EnumType { get; set; }
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // probably add some sanety checks on the involved types and values
            return Enum.ToObject(EnumType, value);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // probably add some sanety checks on the involved types and values
            return System.Convert.ToInt32(value);
        }
    }
