        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((TimeSpan)value).TotalSeconds.ToString(CultureInfo.InvariantCulture);
        }
        /// <see cref="IValueConverter.ConvertBack"/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return TimeSpan.FromSeconds(int.Parse((string) value, NumberStyles.None, CultureInfo.InvariantCulture));
        }
