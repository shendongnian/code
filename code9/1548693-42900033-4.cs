    private static readonly DependencyObject _dummy = new DependencyObject();
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        System.Windows.Media.Color color = Colors.Black;
        if (value != null && value != DependencyProperty.UnsetValue && value is string && !String.IsNullOrWhiteSpace((string) value)) {
            string c = (string) value;
            object convertedColor = null;
            try {
                convertedColor = ColorConverter.ConvertFromString(c);
            }
            catch (Exception ex) {
                if (!DesignerProperties.GetIsInDesignMode(_dummy)) {
                    throw new FormatException($"String {c} does not represent a valid color", ex);
                }
            }
            if (convertedColor != null) {
                color = (Color) convertedColor;
            }
        }
        return color;
    }
