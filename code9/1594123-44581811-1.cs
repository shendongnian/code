    class GridColumnDisplayDataConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new GridColumnDisplayData { DisplayValue = value, ColumnProperty = (string)parameter };
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
