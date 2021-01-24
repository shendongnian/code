        private const string filePath = "your path";
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool val = (bool)value ;
            string path = (val == true) ? $"{filePath}OK icon.png" : $"{filePath}NG icon.png";
            return new Uri(path);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
