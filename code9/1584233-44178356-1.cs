    public class VisibilityConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {               
            bool result = false;
            if (values != null)
            {
                foreach (var item in values)
                {
                    result = (item as string).Length > 0;
                    if (!result) break;
                }                
            }
            return (Visibility)new BooleanToVisibilityConverter().Convert(result, targetType, parameter, culture);
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {            
            return null;
        }
    }  
