    public class NameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var name = (XmlAttribute)value;
            //  Do anything you like in here. This is just an example. 
            return "something based on " + name.Value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
