    public class ItemsSourceConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // doesn't allow to add new rows in DataGrid
            return Enumerable.Repeat(value, 1).ToArray();            
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
