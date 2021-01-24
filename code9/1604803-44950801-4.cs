    public class LanguageNameConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is int)
            {
                var itemLanguageId = (int)values[0];
                var displayLanguageId = (int)values[1];
                //  Do stuff here to get the translated name of the item language
                var itemLanguageNameTranslated = $"Name of language {itemLanguageId} in language {displayLanguageId}";
                return itemLanguageNameTranslated;
            }
            else return values[0]?.GetType();
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
