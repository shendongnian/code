    public class MaddoColorConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            Color color = Colors.Black;
            if (value != null && value != DependencyProperty.UnsetValue && value is string && !String.IsNullOrWhiteSpace((string) value)) {
                string c = (string) value;
                object convertedColor = null;
                try {
                    convertedColor = ColorConverter.ConvertFromString(c);
                }
                catch (Exception ex) {
                    throw new FormatException($"String {c} does not represent a valid color", ex);
                }
                if (convertedColor != null) {
                    color = (Color) convertedColor;
                }
            }
            return color;
        }
    }
