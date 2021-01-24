        public class StringToDoubleConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, string language)
            {
                try
                {
                    return System.Convert.ToString((double)value);
                }
                catch
                {
                    return "";
                }
            }
            public object ConvertBack(object value, Type targetType, object parameter, string language)
            {
                try
                {
                return System.Convert.ToDouble((string)value);
                }
                catch
                {
                    return 0.0;
                }
            }
        }
