    LengthConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((value as string)?.Length??0) > 3;
        }
    }
