    public class MyEnumLocalizationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var e = (MyEnum)value;
            var converted = "";
            //  Do whatever the type converter now does
            return converted;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
