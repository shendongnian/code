    public class TagConverter : IValueConverter
    {
        #region IValueConverter Members
        object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string tag = (string)value;
            return string.IsNullOrEmpty(tag) ? "Your custom string display" : tag;
        }
        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
