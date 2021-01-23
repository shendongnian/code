    class ComparisonConverter : IMultiValueConverter
    {
        private int currentAlternation = 0;
        public int AlternationCount { get; set; } = 2;
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            // TODO: exception handling
            if (values.Distinct().Count() != 1)
            {
                if (++currentAlternation >= AlternationCount)
                {
                    currentAlternation = 0;
                }
            }
            return currentAlternation;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
