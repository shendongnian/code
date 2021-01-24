    SomeImage.DataContext = "pack://application:,,,/.../SomeImagePlaceAtRuntime.png";
    public class SomeImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
        object parameter_, System.Globalization.CultureInfo culture_)
        {
            return (new ImageSourceConverter()).ConvertFromString(value.ToString());
        }
    
        public object ConvertBack(object value, Type targetType,
        object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
