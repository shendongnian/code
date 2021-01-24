    public class StringToGeometryConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var pathStr = "<Geometry xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">" + (string)value + "</Geometry>";
            return (Geometry)XamlReader.Load(pathStr);
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new InvalidOperationException("Cannot convert from Geometry to string");
        }
    }
