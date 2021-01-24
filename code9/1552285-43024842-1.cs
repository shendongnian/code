    public class NameToUriConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            Uri source = value as Uri;
            var path = Enum.IsDefined(typeof(Enumerations.RelicTypes), value.ToString())) 
                ? "/Assets/RelicIcons/Relic_" + (value).ToString() + ".png"
                : "/Assets/Placeholder.png";
            try {
                source = new Uri(path, UriKind.RelativeOrAbsolute);
            } catch {
                source = new Uri(path);
            }
            var img = new BitmapImage();
            img.BeginInit();
            img.UriSource = source;
            img.EndInit();
            return img;            
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotSupportedException();
        }
    }
