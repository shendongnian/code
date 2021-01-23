    //Converter to accept null values in Datagrid not String columns
    class DatagridContentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || ((value.GetType() == typeof(String) && (String)value == "")))
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }
    }
