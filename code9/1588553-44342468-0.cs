    public class AddBaseUrlConverter : IValueConverter
        {
            #region IValueConverter implementation
            private const string BaseImageUrl = "http://eamobiledirectory.com/cooperp/Images/app_images/";
            public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value is string && ! string.IsNullOrEmpty((string)value))  {
                    return string.Format("{0}{1}", BaseImageUrl, (string)value);
                }
                return ""; // 
            }
            public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException ();
            }
            #endregion
        }
