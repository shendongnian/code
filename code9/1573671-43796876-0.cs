    public class SymbolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            // value is Hardware
            // Logic to return symbol
            //retun Symbol.OutlineStar
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
