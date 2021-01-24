      public class StringCaseConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
    
                string param = System.Convert.ToString(parameter) ?? "u";
    
                switch (param.ToUpper())
                {
                    case "U":
                        return ((string)value).ToUpper();
                    case "L":
                        return ((string)value).ToLower();
                    default:
                        return ((string)value);
                }
    
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotSupportedException();
            }
        }
