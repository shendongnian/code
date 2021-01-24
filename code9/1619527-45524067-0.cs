    class ColorConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            bool b = (bool)(value ?? false); // if value is null will default to false
            return b ? Color.Green : Color.Red;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
