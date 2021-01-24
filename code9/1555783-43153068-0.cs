    class StringFormatConverter : IValueConverter
    {
        public string Format { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            dynamic o = value;
            return o.ToString(Format);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
