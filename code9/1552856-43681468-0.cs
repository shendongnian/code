    public class ListViewEvenColumnWidthConverter : IValueConverter
    {
        public int ColumnCount { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return 0;
            double width = (double)value;
            if (width == 0)
                return 0;
            return width / ColumnCount;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException(); 
        }
    }
